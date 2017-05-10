﻿using System;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;
using TrainMovement.ModeControl;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// Pull3
    /// </summary>
    internal class Pull3Rusi4 : BaseModeRusi4<Pull3Rusi4>
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull3Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull3(mass);
        }

        public override IModeControl Low(MassMass mass)
        {
            return InertRusi4.GetInstance(mass);
        }

        public static Pull3Rusi4 GetInstance(MassMass mass)
        {
            return GetInstance<Pull3Rusi4>(mass);
        }
    }
}