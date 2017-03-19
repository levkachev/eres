using System;

namespace TrainMovement.ModeControl
{
    internal class BreakModeControl : IModeControl
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="train"></param>
     /// <returns></returns>
        public Double GetForceBaseResistance(Train.Train train)
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForcePull(Train.Train train)
        {
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForceBreak(Train.Train train)
        {
            return -1;
        }
    }
}

