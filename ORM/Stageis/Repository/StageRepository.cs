using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Lines.Entities;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class StageRepository : Repository<Stage>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static StageRepository GetInstance()
        {
            return GetInstance<StageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// ID перегона по станции отправления и назначения
        /// </summary>
        /// <param name="arrival"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Guid GetStageByNameStation(Guid arrival, Guid department)
        {
            var tmp = GetAll()
                .Where(st => st.Arrival.ID == arrival)
                .SingleOrDefault(st => st.Departure.ID == department);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(arrival));
            return tmp.ID;
        }

        /// <summary>
        /// длина перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Double GetStageLenght(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Length;
        }

        ///// <summary>
        ///// показать все ограничения (скорость и граница скорости) перегона
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<LimitStage> GetStageLimitStage(Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.LimitStages;
        //}
        ///// <summary>
        ///// показать все ARS ограничения (скорость и граница скорости) перегона
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<ASRStage> GetStageASRStage(Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.ASRStages;
        //}
        ///// <summary>
        ///// показать все характеристики открытыеого перегона (KWosn, начало, конец)
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<OpenStage> GetStageOpenStage (Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.OpenStages;
        //}

        ///// <summary>
        ///// показать планы перегона (радиус, граница радиуса)
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<PlanStage> GetStagePlanStage(Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.PlanStages;
        //}

        ///// <summary>
        ///// показать профили перегона (уклон, граница уклона)
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<ProfileStage> GetStageProfileStage(Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.ProfileStages;
        //}

        ///// <summary>
        ///// показать токоразделы перегона (начало, конец)
        ///// </summary>
        ///// <param name="stage"></param>
        ///// <returns></returns>
        //public IEnumerable<CurrentSectionStage> GetStageCurrentSection(Guid stage)
        //{
        //    var tmp = GetAll()
        //        .SingleOrDefault(st => st.ID == stage);
        //    return tmp.CurrentSectionStages;
        //}

        /// <summary>
        /// показать номер пути для перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Int32 GetStageTrack(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Track.Tracks;
        }
    }
}