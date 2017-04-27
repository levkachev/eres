using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;


namespace ORM.Stageis.Repository
{
    public class LimitStageRepository : Repository<LimitStage>
    
    {
        public static LimitStageRepository GetInstance()
        {
            return GetInstance<LimitStageRepository>(SessionWrapper.GetInstance().Factory);
        }
        /// запросы работают, но не используем
        ///// <summary>
        ///// скорость
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<Double> GetStageVelocity(Guid stage)
        //{
           
        //    return GetAll()
        //        .Where(st => st.Stage.ID == stage)
        //        .Select(st => st.Velocity).ToList();
        //}

        ///// <summary>
        ///// Граница скорости
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<Double> GetStageEndVelocity(Guid stage)
        //{

        //    return GetAll()
        //        .Where(st => st.Stage.ID == stage)
        //        .Select(st => st.EndVelocity).ToList();
        //}
    }
}
