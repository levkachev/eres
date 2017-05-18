using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{

    /// <summary>
    /// Pull1
    /// </summary>
    public class Pull1Rusi4 : BaseModeRusi4<Pull1Rusi4>, IPull
    {
       
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private Pull1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull1(mass);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Pull1Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull1Rusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public override IModeControl Low(MassMass mass)
        {
            return BaseModeRusi4<InertRusi4>.GetInstance<InertRusi4>(mass);
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
        /// <returns></returns>
        public override String ToString()
        {
            return $"Pull1";
        }
    }


}
