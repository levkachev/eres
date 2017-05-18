using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break1
    /// </summary>
    public class Break1Rusi4 : BaseModeRusi4<Break1Rusi4>, IRecuperationBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break1(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return Break2Rusi4.GetInstance(mass);
        }

        /// <summary>
        /// Переход в режим торможения со средним замедлением
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl High(MassMass mass)
        {
            return BreakAverageRusi4.GetInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Break1Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break1Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"Break1";
        }
    }
}
