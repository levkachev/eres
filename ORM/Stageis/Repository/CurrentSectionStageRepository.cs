using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrentSectionStageRepository : Repository<CurrentSectionStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static CurrentSectionStageRepository GetInstance()
        {
            return GetInstance<CurrentSectionStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<CurrentSectionStage> GetLimits(Guid stage)
        {
            return GetAll().Where(st => st.Stage.ID == stage);
        }
    }
}
