using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TrainMovement.Repositories
{
    public class MassRepository : Repository<MassMass>
    {
        public static MassRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<MassRepository>(factory);
        }

        public MassMass GetByMass(Double mass)
        {
            return GetAll()
                .Where(tmass => tmass.Mass == mass)
                .SingleOrDefault();
        }
    }
}
