using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break2
    /// </summary>
    public class Break2Rusi4 : BaseModeRusi4<Break2Rusi4>, IRecuperationBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break2(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return BaseModeRusi4<Break3Rusi4>.GetInstance<Break3Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Break2Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break2Rusi4>(mass);
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
        /// <returns></returns>
        public override String ToString()
        {
            return $"Break2";
        }
    }
}

