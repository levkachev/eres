using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ORM.Train.Repositories
{
    public class MassRepository : Repository<MassMass>
    {
        public static MassRepository GetInstance()
        {
            return GetInstance<MassRepository>(SessionWrapper.GetInstance().Factory);
        }

        public MassMass GetByMass(Double mass)
        {
            return GetAll()
                .Where(tmass => tmass.Mass == mass)
                .SingleOrDefault();
        }
    }
}
