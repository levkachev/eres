using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ORM.Energy.Entities;

namespace ERES
{
    [Serializable]
    public class SerializableObject : ISerializable
    {
        private List<EnergyEnergy> energyenergy;

        public List<EnergyEnergy> Energy
        {
            get { return this.energyenergy; }
            set { this.energyenergy = value; }
        }

        public SerializableObject() { }

        public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.energyenergy = (List<EnergyEnergy>)sInfo.GetValue("Energy", typeof(List<EnergyEnergy>));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Energy", this.energyenergy);
        }
    }
}
