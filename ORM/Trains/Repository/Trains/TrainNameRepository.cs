using System;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class TrainNameRepository : Repository<TrainName>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TrainNameRepository GetInstance() => GetInstance<TrainNameRepository>(SessionWrapper.GetInstance().Factory);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override TrainName GetByName(String name) => GetAll().SingleOrDefault(trainName => trainName.Name == name);

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public MotorType GetMotorTypeByName(String name) => GetByName(name)?.MotorType ?? throw new ArgumentOutOfRangeException(nameof(name));
    }
}
