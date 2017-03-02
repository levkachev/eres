using NHibernate;
using ORM.Base;
using ORM.Energy.Repositories;
using System.Collections.Generic;
using System;
using ORM.Line.Repositories;

namespace ERES
{
    class Program
    {
        public static ISessionFactory sessionFactory { get; protected set; }
        static void Main(string[] args)
        {
            sessionFactory = SessionFactory.GetSessionFactory();


            //    var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);

            //ShowCollection<Name>(powerSupplyStationRepository.GetAll, "GetAll");
            // var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);
            //   var powerSupplyStations = powerSupplyStationRepository.GetAll();
            //   ShowCollection<PowerSupplyStation>(powerSupplyStations, "PowerSupplyStations");

            //    ShowCollection<String>(powerSupplyStationRepository.GetPowerSupplyStationNames(), "GetAllNames");


            var linelineRepository = LineLineRepository.GetInstance(sessionFactory);
            var line = linelineRepository.GetByName("Таганско-Краснопресненская");
            
            

            var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);
            var powerSupplyStation = powerSupplyStationRepository.GetPSTbyLine(line,"62");
            var feederRepository = FeederRepository.GetInstance(sessionFactory);
            ShowCollection<String>(feederRepository.GetFeeder(powerSupplyStation), "GetFeeder");

            // Guid id =97A3CBD2-E2AB-4AF2-B47A-EA11E0BBFA5B5;

            //    var powerSupplyStationById = PowerSupplyStationRepository.GetById(97);
            //  ShowCollection<String>(feederRepository.GetFeeder(powerSupplyStationById), "GetFeeder");
            Console.WriteLine("Press any key to close the program");
            Console.ReadKey(true);
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
