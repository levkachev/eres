using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Lines.Entities;

namespace ORM.Lines.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// Хринилище станций.
    /// </summary>
    public class StationRepository : Repository<Station>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static StationRepository GetInstance() => GetInstance<StationRepository>(SessionWrapper.GetInstance().Factory);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public override Station GetByName(String stationName) => GetAll().SingleOrDefault(station => station.Name == stationName);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public override Guid GetIdByName(String stationName)
        {
            try
            {
                return base.GetIdByName(stationName);
            }
            catch (ArgumentException)
            {
                throw new ArgumentOutOfRangeException($"Станция с названием \"{stationName}\" не найдена!", nameof(stationName));
            }
        }

        /// <summary>
        /// для записи в файл, показать все имена станций для выбранной линии (запрос работает, запись нет)
        /// </summary>
        /// <param name="lineName"></param>
        /// <returns></returns>
        public IList<String> GetStationsNamesByLineName(String lineName) => 
            GetAll().Where(station => station.Line.Name.Equals(lineName)).Select(station => station.Name).ToList();
    }
}
