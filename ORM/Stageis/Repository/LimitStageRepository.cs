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
    public class LimitStageRepository : Repository<LimitStage>  
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static LimitStageRepository GetInstance() => GetInstance<LimitStageRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// скорость и Граница скорости
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public IEnumerable<LimitStage> GetLimits(Guid stageId) => GetAll().Where(st => st.Stage.ID == stageId);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override LimitStage GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
