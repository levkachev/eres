using System;
using System.Runtime.Serialization;

namespace ORM.Energies.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Energy : ISerializable
    {
        public Energy() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        public Energy(SerializationInfo sInfo, StreamingContext contextArg)
        {
            NameLine = sInfo.GetString(nameof(NameLine));
            Piketage = sInfo.GetDouble(nameof(Piketage));

            // Бред лютейший!!!
            // PowerSupplyStations = (PowerSupplyStation)sInfo.GetValue("PowerSupplyStations", typeof(PowerSupplyStation));
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue(nameof(NameLine), NameLine, NameLine.GetType());
            sInfo.AddValue(nameof(Piketage), Piketage, Piketage.GetType());
            //sInfo.AddValue("PowerSupplyStation", PowerSupplyStations);
        }

        /// <summary>
        /// 
        /// </summary>
        [System.Xml.Serialization.XmlAttribute("name")]
        public String NameLine;

        /// <summary>
        ///
        /// </summary>
        [System.Xml.Serialization.XmlAttribute("pick")]
        public Double Piketage;

        /// <summary>
        /// 
        /// </summary>
        //  public IEnumerable<PowerSupplyStation> PowerSupplyStation;
    }
}

