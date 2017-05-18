using System;
using ORM.Trains.Entities;
using TrainMovement.ModeControl;

namespace TrainMovement.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    public class InertRusi4 : BaseModeRusi4<InertRusi4>, IInert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Double GetCurrent(Double velocity)
        {
            return 0;
        }

        public override IModeControl Low(MassMass mass)
        {
            return Break1Rusi4.GetInstance(mass);
        }

        public override IModeControl High(MassMass mass)
        {
            throw new NotImplementedException();
        }

        public static InertRusi4 GetInstance(MassMass mass)
        {
            return GetInstance<InertRusi4>(mass);
        }

        /// <summary>
        /// 
        /// </summary>
        private InertRusi4(MassMass mass)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Double GetForce(Double velocity)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return $"Inert";
        }
    }
}