using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Stageis.Repository.Limits;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenStageRepository : Repository<OpenStage>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static OpenStageRepository GetInstance()
        {
            return GetInstance<OpenStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// Коллекция ограничений OpenStage
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<OpenStage> GetLimits(Guid stage)
        {
            return GetAll().Where(st => st.Stage.ID == stage);
        }
    }
}
