using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ORM.Energy.Entities;

namespace ERES
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SerializableObject : ISerializable
    {
        /// <summary>
        /// 
        /// </summary>
        private List<EnergyEnergy> energyenergy;

        /// <summary>
        /// 
        /// </summary>
        public List<EnergyEnergy> Energy
        {
            get { return energyenergy; }
            set { energyenergy = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SerializableObject() { }

        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="name" /> или <paramref name="type" /> — null. </exception>
        /// <exception cref="InvalidCastException">Значение, связанное с <paramref name="name" />, невозможно преобразовать в <paramref name="type" />. </exception>
        /// <exception cref="SerializationException">Элемент с указанным именем не найден в текущем экземпляре. </exception>
        public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        {
            energyenergy = (List<EnergyEnergy>)sInfo.GetValue("Energy", typeof(List<EnergyEnergy>));
        }

        /// <summary>
        /// </summary>
        /// <param name="sInfo"></param>
        /// <param name="contextArg"></param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="name" /> имеет значение null. </exception>
        /// <exception cref="SerializationException">С параметром <paramref name="name" /> уже связано значение. </exception>
        public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        {
            sInfo.AddValue("Energy", this.energyenergy);
        }
    }
}
