using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energy.Entities;
using ORM.Lines.Entities;
using ORM.Stageis.Entities;

namespace ORM.Lines.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class LineRepository : Repository<Line>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static LineRepository GetInstance()
        {
            return GetInstance<LineRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       public ORM.Lines.Entities.Line GetLineId(Guid Id)
       {
           return GetById(Id);
       }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="selector" /> — null.</exception>
        public IList<String> GetLineByName()
        {
            return GetAll()
                .Select(s => s.Name)
                .ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Guid GetIDByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.ID;
        }

        /// <summary>
        /// </summary>
        /// <param name="lineName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public IEnumerable<PowerSupplyStation> GetAllPowerSupplyStations(String lineName)
        {
            var tmp = GetAll()
                .SingleOrDefault(line => line.Name.Equals(lineName));
            return tmp.PowerSupplyStations;
        }

        public IEnumerable<Track> GetAllTrack(String lineName)
        {
            var tmp = GetAll()
               .SingleOrDefault(line => line.Name.Equals(lineName));
            return tmp.Tracks;
        }

        /// <summary>
        /// показать для станции имя и пикетаж
        /// </summary>
        /// <param name="lineName"></param>
        /// <returns></returns>
        public IEnumerable<Station> GetAllStation(String lineName)
        {
            var tmp = GetAll()
               .SingleOrDefault(line => line.Name.Equals(lineName));
            return tmp.Stations;
        }

     



    }
    
}
