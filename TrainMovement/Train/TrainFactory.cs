using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TrainMovement.Machine;
namespace TrainMovement.Train
{
    static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("Type must be serializable");
            if (ReferenceEquals(self, null))
                return default(T);
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    public class TrainFactory
    {
        private static TrainType CommonProperties = new TrainType();

        private static BaseMachine ACMachineProperties = new ACMachine();

        private static BaseMachine DCMachineProperties = new DCMachine();

        public static TrainType NewCommonProperties()
        {
            var result = CommonProperties.DeepCopy();
            return result;
        }

        public static BaseMachine NewACMachineProperties()
        {
            return NewMachine(ACMachineProperties);
        }

        public static BaseMachine NewDCMachineProperties()
        {
            return NewMachine(DCMachineProperties);
        }

        private static BaseMachine NewMachine(BaseMachine machine)
        {
            var result = machine.DeepCopy();
            return result;
        }

    }
}
