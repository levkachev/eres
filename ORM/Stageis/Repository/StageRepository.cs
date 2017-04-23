using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Lines.Entities;

namespace ORM.Stageis.Repository
{
    public class StageRepository : Repository<Stage>

    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static StageRepository GetInstance()
        {
            return GetInstance<StageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrival"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public Guid GetAllStage(Guid arrival, Guid department)
        {
            var tmp = GetAll()
       
                .Where(st => st.Arrival.ID == arrival)
                .Where(st => st.Departure.ID == department)
                
                .SingleOrDefault();
            //.SingleOrDefault(st => st.Arrival.ID == arrival);
            //.SingleOrDefault(st => st.Department.ID == department);
            return tmp.ID;
        }

        public Double GetAllST(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Length;
        }

    }
}