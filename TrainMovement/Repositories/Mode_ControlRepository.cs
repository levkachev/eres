using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TrainMovement.Repositories
{
    public class Mode_ControlRepository : Repository<Mode_Control>

    {
        public static Mode_ControlRepository GetInstance(ISessionFactory factory)
        {
            return GetInstance<Mode_ControlRepository>(factory);
        }

        
        //public IList<Mode_Control> GetByModeControlMotorType(Motor_Type type)
        //{
        //    return GetAll()
        //        .Where(tmodecontrol => tmodecontrol.Motor_Type == type)
        //        .Select(tmodecontrol => tmodecontrol).ToList();  
        //}

        public Mode_Control GetByModeControl(String modecontrol)
        {
            return GetAll()
                .Where(tmodecontrol => tmodecontrol.ModeControl == modecontrol)
                .SingleOrDefault();
        }
    }
}
