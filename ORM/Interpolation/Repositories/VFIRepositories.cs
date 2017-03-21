using ORM.Base;
using NHibernate;
using ORM.Interpolation.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Interpolation.Repositories
{
    public class VFIRepositories : Repository<VFI>

    {
        public static VFIRepositories GetInstance(ISessionFactory factory)
        {
            return GetInstance<VFIRepositories>(factory);
        }
    }
}
