using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.Trains.Interpolation.Entities;
using ORM.Trains.Repository.Trains;

namespace ORM.Trains.Repository.Interpolation
{
    /// <summary>
    /// 
    /// </summary>
    public class VFIRepository : Repository<VFI>

    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static VFIRepository GetInstance()
        {
            return GetInstance<VFIRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="powerSupplyStation"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<VFI> GetVFI(String trainName, ModeControls motorcontrol, MassMass mass)
        {
            return GetAll()
                 .Where(vfi => vfi.Train.Name == trainName)
                 .Where(vfi => vfi.ModeControl == motorcontrol)
                 .Where(vfi => vfi.Mass == mass)
                 .Select(vfi => vfi).ToList();
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public static IEnumerable<VFI> GetVfiRusi4Pull1(MassMass mass)
        {
            var modecontrolRepository = ModeControlsRepository.GetInstance();
            var modecontrol = modecontrolRepository.GetByModeControl("Pull1");
            const String trainName = "81-740.1(Rusi4)";
            var vfiRepository = GetInstance();

            return vfiRepository.GetVFI(trainName, modecontrol, mass);
        }

    }
}
