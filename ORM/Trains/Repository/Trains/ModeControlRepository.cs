using System;
using System.Linq;
using ORM.Base;
using ORM.Train.Entities;

namespace ORM.Trains.Repository.Trains
{
    /// <summary>
    /// 
    /// </summary>
    public class ModeControlRepository : Repository<Mode_Control>

    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModeControlRepository GetInstance()
        {
            return GetInstance<ModeControlRepository>(SessionWrapper.GetInstance().Factory);
        }

        
        //public IList<Mode_Control> GetByModeControlMotorType(Motor_Type type)
        //{
        //    return GetAll()
        //        .Where(tmodecontrol => tmodecontrol.Motor_Type == type)
        //        .Select(tmodecontrol => tmodecontrol).ToList();  
        //}

        /// <summary>
        /// </summary>
        /// <param name="modecontrol"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Mode_Control GetByModeControl(String modecontrol)
        {
            return GetAll()
                .SingleOrDefault(tmodecontrol => tmodecontrol.ModeControl == modecontrol);
        }
    }
}
