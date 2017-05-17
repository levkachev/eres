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
    public class LimitStageRepository : Repository<LimitStage>
    
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static LimitStageRepository GetInstance()
        {
            return GetInstance<LimitStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// скорость и Граница скорости
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<LimitStage> GetLimits(Guid stage)
        {
            return GetAll().Where(st => st.Stage.ID == stage);
        }
    }
}
