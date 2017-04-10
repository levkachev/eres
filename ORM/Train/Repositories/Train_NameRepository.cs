using ORM.Base;
using ORM.Train.Entities;
using System.Linq;
using System;

namespace ORM.Train.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class Train_NameRepository : Repository<Train_Name>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Train_NameRepository GetInstance()
        {
            return GetInstance<Train_NameRepository>(SessionWrapper.GetInstance().Factory);
        }
        public Guid GetIDByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.ID;
        }

        public Motor_Type GetIDMotorTypeByName(String name)
        {
            var tmp = GetAll()
                .SingleOrDefault(tr => tr.Name == name);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(name));
            return tmp.MotorType;
        }
    }
}
