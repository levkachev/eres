using NHibernate;
using ORM.Base;
using System.Linq;
using ORM.Energy.Repositories;
using System.Collections.Generic;
using ORM.Energy.Entities;
using System;

namespace ERES
{
    class Program
    {
        public static ISessionFactory sessionFactory { get; protected set; }
        static void Main(string[] args)
        {
            sessionFactory = SessionFactory.GetSessionFactory();

            //var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);
            //ShowCollection<Name>(powerSupplyStationRepository.GetAll, "GetAll");

            var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);
            var powerSupplyStations = powerSupplyStationRepository.GetAll();
            ShowCollection<PowerSupplyStation>(powerSupplyStations, "PowerSupplyStations");
        }

        private static void ShowCollection<T>(IEnumerable<T> collection, String name)
        {
            Console.WriteLine(new String('_', Environment.CommandLine.Length / 2));
            Console.WriteLine("{1}{0}", name, Environment.NewLine);
            foreach (var item in collection)
                Console.WriteLine(item);
        }

    }
}
