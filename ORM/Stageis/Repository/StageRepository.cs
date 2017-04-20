using System;
using System.Collections.Generic;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class StageRepository : Repository<Stages>
    {
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        internal static StageRepository GetInstance()
        {
            return GetInstance<StageRepository>((SessionWrapper.GetInstance().Factory));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageName"></param>
        /// <returns></returns>
        public static Stages GetStage(String stageName)
        {
            //это, похоже, не нужно...
            var repository = StageRepository.GetInstance();

            // создание списков всех ограничений для данного перегона
            // var speedLimitRepository = SpeedLimitRepository.GetInstance();
            // var speedLimit = speedLimitRepository.GetAll(stageName);
            // var profileLimitRepository = ProfileRepository.GetInstance();
            // var profileLimit = profileLimitRepository.GetAll(stageName);
            //  и т.д.

            //Это заглушка!!!!
            var speedLimit = new SortedSet<LimitStructure>();
            var profileLimit = new SortedSet<LimitStructure>();
            var planLimit = new SortedSet<LimitStructure>();
            var currentSection = new SortedSet<LimitStructure>();
            var automaticSpeedControl = new SortedSet<LimitStructure>();
            var openSection = new SortedSet<LimitStructure>();


            var tmpStage = new Stages(stageName, speedLimit, planLimit, profileLimit, currentSection,
                automaticSpeedControl, openSection);
            return tmpStage;
        }

    }
}
