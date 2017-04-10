using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Base;
using ORM.Stage.Entities;

namespace ORM.Stage.Repositories
{
    public class StageRepository : Repository<StageStage>
    {
        internal static StageRepository GetInstance()
        {
            return GetInstance<StageRepository>((SessionWrapper.GetInstance().Factory));
        }

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
