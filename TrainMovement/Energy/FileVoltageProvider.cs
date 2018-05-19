using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ORM.OldHelpers;

namespace TrainMovement.Energy
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FileVoltageProvider : BaseVoltageProvider
    {
        /// <summary>
        /// Queue of key-value pairs contains piketage (as a key) and voltage (as a value).
        /// </summary>
        private readonly Queue<VoltageOnPiketage> voltages = new Queue<VoltageOnPiketage>();

        /// <summary>
        /// </summary>
        /// <param name="piketage"></param>
        public Double this[Double piketage] => GetVoltage(0, piketage);

        /// <summary>
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="filename"></param>
        /// <param name="separator"></param>
        public FileVoltageProvider(EventBroker broker, String filename, String separator = "; ")
        {
            Broker = broker;
            Read(filename, separator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="separator"></param>
        /// <exception cref="IOException">Ошибка ввода-вывода. </exception>
        /// <exception cref="OutOfMemoryException">Недостаточно памяти для размещения буфера возвращаемых строк. </exception>
        /// <exception cref="ObjectDisposedException">Объект <see cref="T:System.IO.TextReader" /> закрыт. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Количество символов в следующей строке больше <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="path" /> является пустой строкой (""). </exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="path" /> имеет значение null. </exception>
        /// <exception cref="FileNotFoundException">Файл не найден. </exception>
        /// <exception cref="DirectoryNotFoundException">Указанный путь недопустим; возможно, он соответствует неподключенному диску. </exception>
        private void Read(String filename, String separator)
        {
            using (TextReader reader = new StreamReader(filename))
            {
                var currentLine = String.Empty;
                do
                {
                    try
                    {
                        currentLine = reader.ReadLine();
                        voltages.Enqueue(new VoltageOnPiketage(currentLine, separator));
                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                } while (currentLine != null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public override Double GetVoltage(Double current, Double piketage)
        {
            //return voltages.Single(item => MathHelper.IsEqual(item.Piketage, piketage, 0.5)).Voltage;
            var min = voltages.Min(vop => Math.Abs(vop.Piketage - piketage));
            return voltages
                .First(vop => Math.Abs(vop.Piketage - piketage).IsEqual(min))
                .Voltage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piketage"></param>
        /// <returns></returns>
        public override IEnumerable<Double> GetVoltages(Double piketage)
        {
            var min = voltages.Min(vop => Math.Abs(vop.Piketage - piketage));
            return voltages
                .Where(vop => Math.Abs(vop.Piketage - piketage).IsEqual(min))
                .Select(vop => vop.Voltage);
        }
    }
}