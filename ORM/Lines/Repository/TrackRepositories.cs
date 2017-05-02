using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Lines.Entities;

namespace ORM.Lines.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TrackRepository : Repository<Track>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static TrackRepository GetInstance()
        {
            return GetInstance<TrackRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// Выдает немерные пикеты по номеру пути для заданной линии
        /// </summary>
        /// <param name="lineName"></param>
        /// <param name="track"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public IEnumerable<NMLine> GetNMLinesTrack(String lineName, Int32 track)
        {
            var tmp = GetAll()
                .Where(nm => nm.Tracks==track)
                .SingleOrDefault(nm => nm.Line.Name.Equals(lineName));
            return tmp.NMLines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public IEnumerable<NMLine> GetNMForTrack(Track track)
        {
            return = GetAll()
                .SingleOrDefault(tr => tr.ID == track.ID)
                .NMLines;
        }

        /// <summary>
        /// Показать номер пути по выбранному пути
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public Int32 GetNumberTrack(Track track)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.ID == track.ID);
            return tmp.Tracks;
        }

    }
}
