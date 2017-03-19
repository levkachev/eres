using NHibernate;
using ORM.Base;
using ORM.Energy.Repositories;
using System.Collections.Generic;
using System;
using ORM.Line.Repositories;
using ORM.Energy.Entities;
using TrainMovement.Train;



namespace ERES
{
    class Program
    {
        public static ISessionFactory sessionFactory { get; protected set; }
        static void Main(string[] args)
        {
            sessionFactory = SessionFactory.GetSessionFactory();


            /// <summary>
            /// Показать фидеры выбранного типа для выбранной подстанции на выбранной линии
            /// </summary>
            /// 

            var linelineRepository = LineLineRepository.GetInstance(sessionFactory);
            var line = linelineRepository.GetByName("Калининская");

            var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance(sessionFactory);
            var unitRepository = UnitRepository.GetInstance(sessionFactory);

            /// <summary>
            /// Показать всеподстанции на выбранной линии
            /// </summary>
            ShowDictionary(powerSupplyStationRepository.GetAllPSTbyLine(line), "GetAllPSTbyLine");

            /// <summary>
            /// Показать фидеры выбранного типа для выбранной подстанции на выбранной линии
            /// </summary>
            var powerSupplyStation = powerSupplyStationRepository.GetPSTbyLine(line, "88");
            var feederRepository = FeederRepository.GetInstance(sessionFactory);
            //  ShowCollection<String>(feederRepository.GetFeeder(powerSupplyStation), "GetFeeder");
            var type = "питание";
            ShowCollection<Feeder>(feederRepository.GetFeeder(powerSupplyStation, type), "GetFeederTypeP");
            var type1 = "отсос";
            ShowCollection<Feeder>(feederRepository.GetFeeder(powerSupplyStation, type1), "GetFeederTypeO");
            /// <summary>
            /// Показать количество агрегатов, диодов, трансформаторов  для выбранной подстанции на выбранной линии
            /// </summary>
            ShowCollection<Unit>(unitRepository.GetUnit(powerSupplyStation), "GetUnit");

            Console.WriteLine("Press any key to close the program");
            Console.ReadKey(true);


     //       try
     //       {
     //           //var train = new Train.Train();
      //          var properties = TrainFactory.NewCommonProperties();
     //           var ACmachine = TrainFactory.NewACMachineProperties();
      //      }
      //      catch (Exception exception)
      //      {
       //         Console.WriteLine(exception);
       //     }
            
        //    Console.ReadKey(true);

        }
       


        private static void ShowCollection<T>(IEnumerable<T> collection, String name)
        {
            Console.WriteLine(new String('_', Environment.CommandLine.Length / 2));
            Console.WriteLine("{1}{0}", name, Environment.NewLine);
            foreach (var item in collection)
                Console.WriteLine(item);
        }

        private static void ShowDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, String name)
        {
            Console.WriteLine(new String('_', Environment.CommandLine.Length / 2));
            Console.WriteLine($"{name}{Environment.NewLine}");
            foreach (var item in dictionary)
                //      Console.WriteLine($"In the {item.Key} where are {item.Value}");
                Console.WriteLine($"{item.Key}, {item.Value}");
        }
    }
}
