using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Lines.Entities;
using ORM.Stageis.Entities;

namespace ORM.Lines.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class StationRepository : Repository<Station>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static StationRepository GetInstance()
        {
            return GetInstance<StationRepository>(SessionWrapper.GetInstance().Factory);
        }

        public Guid GetIDByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.ID;
        }
    }
}
