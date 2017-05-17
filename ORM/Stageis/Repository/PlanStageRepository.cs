using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PlanStageRepository: Repository<PlanStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static PlanStageRepository GetInstance()
        {
            return GetInstance<PlanStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<PlanStage> GetLimits(Guid stage)
        {
            return GetAll().Where(st => st.Stage.ID == stage);
        }
    }
}
