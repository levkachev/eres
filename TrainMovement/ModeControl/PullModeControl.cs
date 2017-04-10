using System;

namespace TrainMovement.ModeControl
{
    public enum ModeControlType : byte
    {
        Pull = 1,
        Inert = 2,
        Break = 3
    }
    /// <summary>
    /// 
    /// </summary>

    internal class PullModeControl : IModeControl
    {
        /// <summary>
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
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForceBreak(Train.BaseTrain train)
        {
            return 0;
        }
    }
}
