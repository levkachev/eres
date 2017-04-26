using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    public class OpenStageRepository : Repository<OpenStage>

    {
        public static OpenStageRepository GetInstance()
        {
            return GetInstance<OpenStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// KWosn
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<Double> GetStageKWosn(Guid stage)
        {
            return GetAll()
           .Where(st => st.Stage.ID == stage)
           .Select(st => st.KWosn).ToList();
        }
    }
}
