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
    public class ASRStageRepository : Repository<ASRStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ASRStageRepository GetInstance() => GetInstance<ASRStageRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public IEnumerable<ASRStage> GetLimits(Guid stageId) => GetAll().Where(st => st.Stage.ID == stageId);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override ASRStage GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
