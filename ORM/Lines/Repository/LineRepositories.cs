using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energies.Entities;
using ORM.Lines.Entities;

namespace ORM.Lines.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// Хранилище линий.
    /// </summary>
    public class LineRepository : Repository<Line>
    {
        /// <summary>
        /// Метод получения объекта хранилища для взаимодействия с ним.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static LineRepository GetInstance() => GetInstance<LineRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// Метод, извлекающий из хранилища коллекцию названий всех хранимых линий.
        /// </summary>
        /// <returns></returns>
        public IList<String> GetAllLineNames() => GetAll().Select(s => s.Name).ToList();

        /// <inheritdoc />
        /// <summary>
        /// Метод, извлекающий из хранилища линию по её уникальному названию.
        /// </summary>
        /// <param name="lineName">Уникальное название линии.</param>
        /// <returns>Линия с названием <paramref name="lineName" /> или <see langword="null" />.</returns>
        public override Line GetByName(String lineName) => GetAll().SingleOrDefault(line => line.Name == lineName);

        /// <inheritdoc />
        /// <summary>
        /// Метод, извлекающий из хранилища код (<see cref="Guid"/>) объекта по его (объекта) наименованию.
        /// </summary>
        /// <param name="lineName">Уникальное название линии.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        public override Guid GetIdByName(String lineName)
        {
            try
            {
                return base.GetIdByName(lineName);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException($"Линия с именем \"{lineName}\" не найдена!", nameof(lineName));
            }
        }

        /// <summary>
        /// Метод, извлекающий коллекцию всех тяговых подстанций, обслуживающих линию с именем <paramref name="lineName"/>.
        /// </summary>
        /// <param name="lineName">Уникальное название линии.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        public IEnumerable<PowerSupplyStation> GetAllPowerSupplyStations(String lineName) => 
            GetByName(lineName)?.PowerSupplyStations ?? throw new ArgumentException($"Линия с именем \"{lineName}\" не найдена!", nameof(lineName));

        /// <summary>
        /// Метод, извлекающий коллекцию всех путей, принадлежащих линии с именем <paramref name="lineName"/>.
        /// </summary>
        /// <param name="lineName">Уникальное название линии.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        public IEnumerable<Track> GetAllTrack(String lineName) => 
            GetByName(lineName)?.Tracks ?? throw new ArgumentException($"Линия с именем \"{lineName}\" не найдена!", nameof(lineName));

        /// <summary>
        /// Метод, извлекающий коллекцию всех станций, принадлежащих линии с именем <paramref name="lineName"/>.
        /// </summary>
        /// <param name="lineName">Уникальное название линии.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"/>
        public IEnumerable<Station> GetAllStation(String lineName) => 
            GetByName(lineName)?.Stations ?? throw new ArgumentException($"Линия с именем \"{lineName}\" не найдена!", nameof(lineName));
    } 
}
