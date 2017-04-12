using System;
using TrainMovement.Train;

namespace TrainMovement.ModeControl
{
    /// <summary>
    /// Режим движения Ход1 для AC поезда Русич
    /// </summary>
    public sealed class Pull1ACRusi4 : BaseACRusi4BaseResistance, IModeControl
    {
        /// <summary>
        /// Need to be hidden.
        /// </summary>
        private Pull1ACRusi4() { }

        /// <summary>
        /// Instance of singleton object.
        /// </summary>
        private static Pull1ACRusi4 instance;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Pull1ACRusi4 GetInstance()
        {
            if (instance == null)
                instance = new Pull1ACRusi4();
            return instance;
        }

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
