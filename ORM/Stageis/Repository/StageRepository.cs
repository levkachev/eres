﻿using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Lines.Entities;

namespace ORM.Stageis.Repository
{
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
        public Guid GetStageByNameStation(Guid arrival, Guid department)
        {
            var tmp = GetAll()
       
                .Where(st => st.Arrival.ID == arrival)
                .Where(st => st.Departure.ID == department)
                .SingleOrDefault();
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(arrival));
            return tmp.ID;
        }
        /// <summary>
        /// длина перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public Double GetStageLenght(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Length;
        }

        /// <summary>
        /// показать все ограничения перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<LimitStage> GetStageLimitStage(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.LimitStages;
        }

        public IEnumerable<ASRStage> GetStageASRStage(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.ASRStages;
        }
    }
}