using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ORM.Energies.Entities;

namespace ERES
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [Serializable]
    public class SerializableObject : ISerializable
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlArray(ElementName = "Energies")]
        [XmlArrayItem("text", Type = typeof(Energy))]
        public List<Energy> Energies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SerializableObject() { }

        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        {
            Energies = (List<Energy>)sInfo.GetValue("Energies", typeof(List<Energy>));
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Energies", Energies);
        }
    }
}
