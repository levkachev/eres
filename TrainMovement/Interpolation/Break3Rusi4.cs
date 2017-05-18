using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Break3
    /// </summary>
    public class Break3Rusi4 : BaseModeRusi4<Break3Rusi4>, IRecuperationBreak
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Break3Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Break3(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Break3Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Break3Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return this;
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
            return $"Break3";
        }
    }
}
