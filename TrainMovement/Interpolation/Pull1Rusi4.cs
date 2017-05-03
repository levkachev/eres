using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Trains.Interpolation.Entities;
using ORM.Trains.Entities;
using ORM.Trains.Repository.Interpolation;


namespace TrainMovement.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    internal class Pull1Rusi4 : BaseModeRusi4
    {
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        internal Pull1Rusi4(MassMass mass)
        {
            ForceAndCurrent = VFIRepository.GetVfiRusi4Pull1(mass);
        }
    }
}
