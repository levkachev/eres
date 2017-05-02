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
    public class ASRStageRepository : Repository<ASRStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ASRStageRepository GetInstance()
        {
            return GetInstance<ASRStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<ASRStage> GetLimits(Guid stage)
        {

            return GetAll()
                .Where(st => st.Stage.ID == stage)
                .Select(st => new ASRStage());
        }
    }
}
