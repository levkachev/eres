using System;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// Режим движения Ход1 для AC поезда Русич
    /// </summary>
    public class Pull1ACRusi4 : BaseACRusi4BaseResistance, IPullBreakControl
    {
        /// <summary>
        /// Ток
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetCurrent(BaseTrain train)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сила тяги
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetPullOrBreak(BaseTrain train)
        {
            throw new NotImplementedException();
        }
    }
}
