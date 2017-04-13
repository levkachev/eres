using System;
using ORM.Base;
using ORM.Stage.Entities;

namespace Repositories.Stages
{
    /// <summary>
    /// 
    /// </summary>
    public class StageRepository : Repository<StageStage>
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
        public static StageStage GetStage(String stageName)
        {
            var repository = StageRepository.GetInstance();
            // var speedLimitRepository = SpeedLimitRepository.GetInstance();
            // var speedLimit = speedLimitRepository.GetAll(stageName);
            var tmpStage =  new StageStage();
            tmpStage.Name = stageName;
            //tmpStage.SpeedLimit = speedLimit;
            return tmpStage;
        }
    }
}
