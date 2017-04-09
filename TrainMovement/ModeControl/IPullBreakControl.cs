using System;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPullBreakControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetPullOrBreak(BaseTrain train);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        Double GetCurrent(BaseTrain train);
    }
}