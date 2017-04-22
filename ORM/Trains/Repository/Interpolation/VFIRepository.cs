using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Trains.Entities;
using ORM.Trains.Interpolation.Entities;

namespace ORM.Trains.Repository.Interpolation
{
    public class VFIRepository : Repository<VFI>

    {
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
        public IList<VFI> GetVFI(String trainName, ModeControls motorcontrol, MassMass mass)
        {
            return GetAll()
                 .Where(vfi => vfi.Train.Name == trainName)
                 .Where(vfi => vfi.ModeControl == motorcontrol)
                 .Where(vfi => vfi.Mass == mass)
                 .Select(vfi => vfi).ToList();
        }
         
    }
}
