using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PlanStageRepository : Repository<PlanStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static PlanStageRepository GetInstance() => GetInstance<PlanStageRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public IEnumerable<PlanStage> GetLimits(Guid stageId) => GetAll().Where(st => st.Stage.ID == stageId);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override PlanStage GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
