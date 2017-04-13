using System;
using System.Runtime.Serialization;


namespace ORM.Energy.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class EnergyEnergy : ISerializable
    {
        /// <summary>
        /// 
        /// </summary>
        public EnergyEnergy() { }

        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="name" /> или <paramref name="type" /> — null. </exception>
        /// <exception cref="InvalidCastException">Значение, связанное с <paramref name="name" />, невозможно преобразовать в <paramref name="type" />. </exception>
        public EnergyEnergy(SerializationInfo sInfo, StreamingContext contextArg)
        {
            NameLine = (String)sInfo.GetValue("NameLine", typeof(String));
            
           // Piketag = (Double)sInfo.GetValue("Piketage", typeof(Double));
          /// PowerSupplyStations = (PowerSupplyStation)sInfo.GetValue("PowerSupplyStations", typeof(PowerSupplyStation));
        }

        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="name" /> имеет значение null. </exception>
        /// <exception cref="SerializationException">С параметром <paramref name="name" /> уже связано значение. </exception>
        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("NameLine", NameLine);
            sInfo.AddValue("Piketage", Piketag);
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
        //  public IEnumerable<PowerSupplyStation> PowerSupplyStation;
        [System.Xml.Serialization.XmlAttribute("pick")]
        public Double Piketag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speedLmit"></param>
    //    public EnergyEnergy()
    //    {
   //         PowerSupplyStation = new SortedSet<PowerSupplyStation>();
   //     }
    }
}

