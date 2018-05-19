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
    public class OpenStageRepository : Repository<OpenStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static OpenStageRepository GetInstance() => GetInstance<OpenStageRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// Коллекция ограничений OpenStage
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public IEnumerable<OpenStage> GetLimits(Guid stageId) => GetAll().Where(st => st.Stage.ID == stageId);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override OpenStage GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}
