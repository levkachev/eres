using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository;
using TrainMovement.ModeControl;
using TrainMovement.Train;

namespace TrainMovement.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    public class BreakAverageRusi4: IModeControl, IAverageBreak
    {
        /// <summary>
        /// 
        /// </summary>
        private static BreakAverageRusi4 instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public Double GetForce(Double velocity)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public Double GetCurrent(Double velocity)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetBaseResistance(BaseTrain train)
        {
            var massRepository = MassRepository.GetInstance();
            var byMass = massRepository.GetByMass(train.Mass);
            var modeControl = Break1Rusi4.GetInstance(byMass);
            return modeControl.GetBaseResistance(train);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public IModeControl Low(MassMass mass)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <returns></returns>
        public IModeControl High(MassMass mass)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        private BreakAverageRusi4()
        {}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BreakAverageRusi4 GetInstance()
        {
            if (instance == null)
                instance = new BreakAverageRusi4();
            return instance;
        }
    }
}