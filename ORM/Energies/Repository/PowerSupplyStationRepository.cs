using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Energies.Entities;

namespace ORM.Energies.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class PowerSupplyStationRepository : Repository<PowerSupplyStation>
    
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static PowerSupplyStationRepository GetInstance() => GetInstance<PowerSupplyStationRepository>(SessionWrapper.GetInstance().Factory);


        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public override PowerSupplyStation GetByName(String powerSupplyStationName) => GetAll().SingleOrDefault(s => s.Name == powerSupplyStationName);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public IList<String> GetPowerSupplyStationNames() => GetAll().Select(s => s.Name).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PowerSupplyStation GetPowerSupplyStationId(Guid id) => GetById(id);

        /// <summary>
        /// Подстанция для выбранной линии по наименованию подстанции
        /// </summary>
        /// <param name="line"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public PowerSupplyStation GetPSTbyLine(Guid line, String name)
        {
            return GetAll()
                .Where(pst => pst.Line.ID == line)
                .SingleOrDefault(pst => pst.Name == name);
               
        }

        /// <summary>
        /// все подстаниции для выбранной линии
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="ArgumentException">Функция <paramref name="keySelector" /> выдает дубликаты ключей для двух элементов.</exception>
        public IDictionary<String, Double> GetAllPSTbyLine(Guid line)
        {
            return GetAll()
                .Where(pst => pst.Line.ID == line)
                .ToDictionary(pst => pst.Name, pst => pst.Piketage);

        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="InvalidOperationException">Входная последовательность содержит более одного элемента.</exception>
        public  Double GetAllPST(Guid line, String name)
        {
            return GetAll()
                .Where(pst => pst.Line.ID == line)
                .Where(pst => pst.Name == name)
                .Select(pst => pst.Piketage)
                .SingleOrDefault();
                
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public IEnumerable<PowerSupplyStation> GetPowerStations(Guid line)
        {
            return GetAll()
                .Where(ps => ps.Line.ID == line)
                .Select(ps => ps)
                .ToList();
        }
    }
}
