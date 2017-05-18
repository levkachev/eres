using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation
{/// <summary>
 /// Pull2
 /// </summary>
    public class Pull2Rusi4 : BaseModeRusi4<Pull2Rusi4>, IPull
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull2Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull2(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return InertRusi4.GetInstance(mass);
        }

        public override IModeControl High(MassMass mass)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Pull2Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull2Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"Pull2";
        }
    }
}
