using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ORM.Energy.Entities
{
    [Serializable]
    public class EnergyEnergy : ISerializable
    {
        public EnergyEnergy() { }
        public EnergyEnergy(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.NameLine = (string)sInfo.GetValue("NameLine", typeof(string));
            this.Piketag = (double)sInfo.GetValue("Piketag", typeof(double));
            // this.PowerSupplyStation = (PowerSupplyStation)sInfo.GetValue("PowerSupplyStation", typeof(PowerSupplyStation));
        }

        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("NameLine", this.NameLine);
            sInfo.AddValue("Piketag", this.Piketag);
           // sInfo.AddValue("PowerSupplyStation", this.PowerSupplyStation);
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

