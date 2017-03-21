using ORM.Base;
using NHibernate;
using ORM.Interpolation.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Interpolation.Repositories
{
    public class VFIRepository : Repository<VFI>

    {
        public static VFIRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<VFIRepository>(factory);
        }
    }
}
