using System;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <inheritdoc />
    /// <summary>
    /// Хранилище типов двигателей.
    /// </summary>
   public class MotorTypeRepository : Repository<MotorType>
    {
        /// <summary>
        /// Метод, получающий инстанс хранилища.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static MotorTypeRepository GetInstance() => GetInstance<MotorTypeRepository>(SessionWrapper.GetInstance().Factory);

        /// <inheritdoc />
        /// <summary>
        /// Метод, извлекающий из хранилища объект (тип двигателя) по его уникальному наименованию.
        /// </summary>
        /// <param name="motorTypeName">Уникальное наименование типа двигателя (AC, DC).</param>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException" />
        public override MotorType GetByName(String motorTypeName) => GetAll().SingleOrDefault(motorType => motorType.Name == motorTypeName);
    }
}