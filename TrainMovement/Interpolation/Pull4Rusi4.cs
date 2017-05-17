using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Pull4
    /// </summary>
    public class Pull4Rusi4 : BaseModeRusi4<Pull4Rusi4>, IPull
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Pull4Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull4(mass);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl High(MassMass mass)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Pull4Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull4Rusi4>(mass);
        }
    }
}

