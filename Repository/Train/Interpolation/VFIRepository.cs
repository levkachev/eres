using ORM.Base;
using NHibernate;
using ORM.Interpolation.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using ORM.Train.Entities;

namespace ORM.Interpolation.Repositories
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
        public IList<VFI> GetVFI(String trainName, Mode_Control motorcontrol, MassMass mass)
        {
            return GetAll()
                 .Where(vfi => vfi.Train.Name == trainName)
                 .Where(vfi => vfi.ModeControl == motorcontrol)
                 .Where(vfi => vfi.Mass == mass)
                 .Select(vfi => vfi).ToList();
        }
         
    }
}
