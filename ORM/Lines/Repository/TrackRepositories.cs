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

   
        
        
    }
}
