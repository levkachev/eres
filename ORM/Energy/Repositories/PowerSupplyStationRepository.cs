using ORM.Base;
using NHibernate;
using ORM.Energy.Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using ORM.Line.Entities;



namespace ORM.Energy.Repositories
{
    public class PowerSupplyStationRepository : Repository<PowerSupplyStation>
    
    {
       public static PowerSupplyStationRepository GetInstance()
        {
            return GetInstance<PowerSupplyStationRepository>(SessionWrapper.GetInstance().Factory);
        }

        

        public PowerSupplyStation GetPowerSupplyStation(String PowerSupplyStationName)
        {
            return GetAll()
                .SingleOrDefault(s => s.Name == PowerSupplyStationName);
        }
        public IList<String> GetPowerSupplyStationNames()
        {
            return GetAll()
                .Select(s => s.Name)
                .ToList();
        }

        public PowerSupplyStation GetPowerSupplyStationId(Guid Id)
        {
            return GetById(Id);
        }
      
        public PowerSupplyStation GetByName(String name)
        {
            return GetAll()
                .Where(pst => pst.Name == name)
                .SingleOrDefault();
        }
       /// <summary>
       /// Подстанция для выбранной линии по наименованию подстанции
       /// </summary>
       /// <param name="line"></param>
       /// <param name="name"></param>
       /// <returns></returns>
        public PowerSupplyStation GetPSTbyLine(LineLine line, String name)
        {
            return GetAll()
                .Where(pst => pst.Line == line)
                .Where(pst => pst.Name == name)
                .SingleOrDefault();
               
        }
        /// <summary>
        /// все подстаниции для выбранной линии
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IDictionary<String, Double> GetAllPSTbyLine(LineLine line)
        {
            return GetAll()
                .Where(pst => pst.Line == line)
                .ToDictionary(pst => pst.Name, pst => pst.Piketag);

        }
    }
}
