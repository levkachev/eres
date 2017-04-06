using System;

namespace TrainMovement.ModeControl
{
    internal class BreakModeControl : IModeControl
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="train"></param>
     /// <returns></returns>
        public Double GetForceBaseResistance(Train.BaseTrain train)
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForcePull(Train.BaseTrain train)
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForceBreak(Train.BaseTrain train)
        {
            return -1;
        }
    }
}

