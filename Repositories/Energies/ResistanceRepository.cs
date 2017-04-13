using System;
using ORM.Base;
using ORM.Energy.Entities;

namespace Repositories.Energies
{
    /// <summary>
    /// 
    /// </summary>
    public class ResistanceRepository : Repository<Resistance>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ResistanceRepository GetInstance()
        {
            return GetInstance<ResistanceRepository>(SessionWrapper.GetInstance().Factory);
        }
    }
}
