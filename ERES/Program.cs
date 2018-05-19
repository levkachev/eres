/**
 * Comment by const_phi.
 */

using System.Collections.Generic;
using System;
using ORM.Energies.Entities;
using ORM.Lines.Entities;
using System.IO;
using System.Linq;
using System.Windows;
using ORM.OldHelpers;
using ORM.Lines.Repository;
using ORM.Stageis.Repository;
using ORM.Trains.Repository;
using TrainMovement;
using TrainMovement.Energy;
using TrainMovement.ModeControl;
using TrainMovement.Stage;
using TrainMovement.Train;
using Helpers.Math;
using ORM.Trains.Repository.Interpolation;
using ORM.Trains.Repository.Trains;
using Point = Helpers.Math.Point;

namespace ERES
{
    internal class Program
    {
        /// <summary>
        /// Шаг моделирования в секундах.
        /// </summary>
        public const Double StepOfIntegration = 0.1;

        /// <summary>
        /// Масса масса состава в тоннах (для 81-740.1 в БД есть кривые ТОЛЬКО для этого значения).
        /// </summary>
        public const Double MassForInterpolation = 100;

        //   public static ISessionFactory sessionFactory { get; protected set; }

        private static void Main()
        {
            //var sll = new SortedLinkedList<Int32>(SortedLinkedList<Int32>.SortingOrder.Ascending, null, 5, 3, 7, 10, -11, 24);
            //foreach (var i in sll)
            //    Console.WriteLine(i);

            //Console.WriteLine($"{{{String.Join("; ", sll)}}}");



            Test_PiecewiseLinerFunction();


            //  sessionFactory = SessionFactory.GetSessionFactory();

            // Показать фидеры выбранного типа для выбранной подстанции на выбранной линии


            //var linelineRepository = LineRepository.GetInstance();
            //var line = linelineRepository.GetIDByName("Калининская");

            //var powerSupplyStationRepository = PowerSupplyStationRepository.GetInstance();
            //var unitRepository = UnitRepository.GetInstance();

            ///// <summary>
            ///// Показать все подстанции на выбранной линии
            ///// </summary>
            //ShowDictionary(powerSupplyStationRepository.GetAllPSTbyLine(line), "GetAllPSTbyLine");

            ///// <summary>
            ///// Показать фидеры выбранного типа для выбранной подстанции на выбранной линии
            ///// </summary>
            //var powerSupplyStation = powerSupplyStationRepository.GetPSTbyLine(line, "88");
            //var feederRepository = FeederRepository.GetInstance();
            ////  ShowCollection<String>(feederRepository.GetFeeder(powerSupplyStation), "GetFeeder");
            //var type = "питание";
            //ShowCollection<Feeder>(feederRepository.GetFeeder(powerSupplyStation, type), "GetFeederTypeP");
            //var type1 = "отсос";
            //ShowCollection<Feeder>(feederRepository.GetFeeder(powerSupplyStation, type1), "GetFeederTypeO");
            ///// <summary>
            ///// Показать количество агрегатов, диодов, трансформаторов  для выбранной подстанции на выбранной линии
            ///// </summary>
            //ShowCollection<Unit>(unitRepository.GetUnit(powerSupplyStation), "GetUnit");


            /////показать для выбранного типа мотора, имени поезда и массы все зависимости
            ///// </summary> 
            ///// 
            //var testTrainName = "81-740.4";

            //var motortypeRepository = MotorTypeRepository.GetInstance();
            //var motortype = motortypeRepository.GetByName("AC");

            //var trainnameRepository = TrainNameRepository.GetInstance();
            //var trainname = trainnameRepository.GetIDByName("81-740.4");

            var mass = MassRepository.GetInstance().GetByMass(MassForInterpolation);

            //var modecontrolRepository = ModeControlRepository.GetInstance();
            //var modecontrol = modecontrolRepository.GetByName("Pull1");

            //var vfiRepository = ElectricTractionCharacteristicsRepository.GetInstance();
            //ShowCollection<ElectricTractionCharacteristics>(vfiRepository.GetCharacteristics(testTrainName, modecontrol, mass), "GetCharacteristics");

            const String nameLine = "Калининская";

            var lineRepository = LineRepository.GetInstance();
            //var PSS = lineRepository.GetAllPowerSupplyStations(nameLine);
            //ShowCollection<PowerSupplyStation>(PSS, "PowerSupplyStations");

            var track = lineRepository.GetAllTrack(nameLine);
            //ShowCollection<Track>(track, "Track");

            var stationRepository = StationRepository.GetInstance();
            //var arrival = stationRepository.GetIdByName("Площадь Ильича");
            //var department = stationRepository.GetIdByName("Марксистская");

            const String arrivalStationName = "Новогиреево";
            var arrival = stationRepository.GetIdByName(arrivalStationName);

            const String departureStationName = "Перово";
            var department = stationRepository.GetIdByName(departureStationName); 

            var stageRepository = StageRepository.GetInstance();
            var stageId = stageRepository.GetStageByNameStation(arrival, department);
            var length = stageRepository.GetStageLength(stageId);

            var broker = new EventBroker();

            var stage = StationToStationBlock.GetStageWithoutASR(stageId, broker);

            ICountVoltage voltage = new ConstantVoltageProvider(broker, 825);
           // ICountVoltage voltage = new FileVoltageProvider(broker, "UmaxXX.txt", "\t");
            
            try
            {
                const String trainName = "81-740.1(Rusi4)";
                var train = TrainFactory.GetACTrain(trainName, broker);
                IModeControl modeControl = TrainMovement.Interpolation.Rusi4.Pull4.GetInstance(mass);
                train.Start(stageId, 11);
                var move = new List<OutTrainParameters>();
                var step = train.Move(500, modeControl, MassForInterpolation, StepOfIntegration).ToList();
                move.AddRange(step);

                modeControl = TrainMovement.Interpolation.Rusi4.Inert.GetInstance(mass);
                step = train.Move(1650, modeControl, MassForInterpolation, StepOfIntegration).ToList();
                move.AddRange(step);

                modeControl = TrainMovement.Interpolation.Rusi4.Break2.GetInstance(mass);
                step = train.Move(length, modeControl, MassForInterpolation, StepOfIntegration).ToList();
                move.AddRange(step);
                PrintToFile(move, "moving");

                //var bat = new OptimalTrajectory.BranchesAndTreesMethod();
                //var solver = new OptimalTrajectory.Solver();
                //var trajectory = solver.Solve(train, stage, bat);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //modeControl = TrainMovement.Interpolation.Inert.GetInstance(mass);
            //step = train.Move(1765, modeControl).ToList();
            //move.AddRange(step);

            //modeControl = TrainMovement.Interpolation.Break2.GetInstance(mass);
            //step = train.Move(2048, modeControl).ToList();
            //move.AddRange(step);



            //ShowCollection<OutTrainParameters>(move, "moving");


            //const Double piketage = 25.50;
            //var filename = "UmaxXX.txt";
            //try
            //{
            //    var factory = new VoltageProviderFactory(broker);
            //    var voltageProvider = factory.GetVoltageProvider(filename, "\t");
            //    var value = voltageProvider[piketage];
            //    Console.WriteLine($"voltage for piketage = {piketage} is {value}");
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //}





            Console.WriteLine("the end");
            // var length = stageRepository.GetStageLength(st);
            // Console.WriteLine(Convert.ToString(length), "StageLenght");

            //  var station = lineRepository.GetAllStation(nameLine);
            // //var station = stationRepository.GetStationsNamesByLineName(nameLine);
            // ShowCollection<Station>(station, "Station");

            // var trackRepository = TrackRepository.GetInstance();
            // var nmlinetrack1 = trackRepository.GetNMLinesTrack(nameLine,1);
            // ShowCollection<NMLine>(nmlinetrack1, "NMLineTrack1");

            // var nmlinetrack2 = trackRepository.GetNMLinesTrack(nameLine, 2);
            // ShowCollection<NMLine>(nmlinetrack2, "NMLineTrack2");


            // //var limitStage = stageRepository.GetStageLimitStage(st);
            // //ShowCollection<LimitStage>(limitStage, "LimitStage");

            // //var ARSStage = stageRepository.GetStageASRStage(st);
            // //ShowCollection<ASRStage>(ARSStage, "ASRStage");

            // //var openstage = stageRepository.GetStageOpenStage(st);
            // //ShowCollection<OpenStage>(openstage, "OpenStage");

            // //var planstage = stageRepository.GetStagePlanStage(st);
            // //ShowCollection<PlanStage>(planstage, "PlanStage");

            // //var profilestage = stageRepository.GetStageProfileStage(st);
            // //ShowCollection<ProfileStage>(profilestage, "ProfileStage");


            // //var currentstage = stageRepository.GetStageCurrentSection(st);
            // //ShowCollection<CurrentSectionStage>(currentstage, "CurrentSectionStage");

            // var tr = stageRepository.GetStageTrack(st);
            // Console.WriteLine("NumberTrack");
            // Console.WriteLine(Convert.ToString(tr));

            // //string pathToFile = @"C:\Users\Valeriyа\Desktop";
            // //string filename = "StationPiketage";
            // //string format = ".txt";
            // //string path = Path.Combine(pathToFile, filename) + format;


            // //string[] rows = { Convert.ToString(station) };

            // //FileInfo file = new FileInfo(path);
            // //if (file.Exists == false)
            // //{
            // //    file.Create().Close();
            // //    Console.WriteLine("File add to path!");
            // //}
            // //else Console.WriteLine("File exist! Rename file!");

            // //--тоже работает
            // //var str = new StringBuilder();
            // //foreach (var row in rows)

            // //    str.Append(row);

            ////--

            // //var strToFile = String.Join(" ", rows);

            // //File.WriteAllText(path, strToFile);


            // ////NMLines Track=1
            // //string nameFile1 = "NMLinesTrack1";
            // //string path1 = Path.Combine(pathToFile, nameFile1) + format;
            // //string[] rows1 = { Convert.ToString(nmlinetrack1) };

            // //FileInfo file1 = new FileInfo(path1);
            // //if (file1.Exists == false)
            // //{
            // //    file1.Create().Close();
            // //    Console.WriteLine("File add to path!");
            // //}
            // //else Console.WriteLine("File exist! Rename file!");
            // //var strToFile1 = String.Join(" ", rows1);

            // //File.WriteAllText(path1, strToFile1);


            // ////NMLines Track=2
            // //string nameFile2 = "NMLinesTrack2";
            // //string path2 = Path.Combine(pathToFile, nameFile2) + format;
            // //string[] rows2 = { Convert.ToString(nmlinetrack2) };

            // //FileInfo file2 = new FileInfo(path2);
            // //if (file1.Exists == false)
            // //{
            // //    file1.Create().Close();
            // //    Console.WriteLine("File add to path!");
            // //}
            // //else Console.WriteLine("File exist! Rename file!");
            // //var strToFile2 = String.Join(" ", rows2);

            // //File.WriteAllText(path2, strToFile2);



            // var nmLines = stageRepository.GetNMForStage(st);
            // var nmConvertedLines = NMConvertLimitStage.GetLimits(nmLines);
            // Console.WriteLine(String.Join(";", nmConvertedLines));

            Console.ReadKey();

            //List<EnergyEnergy> energyeneregy = new List<EnergyEnergy>();

            //SerializableObject obj = new SerializableObject();
            //obj.Energies = energyeneregy;

            //MySerializer serializer = new MySerializer();
            ////serializer.SerializeObject("output.txt", obj);
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("output.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, obj);
            //stream.Close();

            //obj = serializer.DeserializeObject("output.txt");
            //energyeneregy = obj.Energies;


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

        private static void Test_PiecewiseLinerFunction()
        {
            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(2, 2),
                new Point(5, 2),
                new Point(9, 0)
            };

            var heap = new PiecewiseLinearFunction(points);
            for (var x = 0.0; x < 10; x += 0.25)
                Console.WriteLine($"{x:F2} --> | {heap[x]} |");
        }

        private static void Test_ModeControlRepo()
        {
            var motorType = MotorTypeRepository.GetInstance().GetByName("");
            var controls = ModeControlRepository.GetInstance().GetModeControlsForMotorType(motorType);
        }

        private static void PrintToFile<T>(IEnumerable<T> collection, String name)
        {
            var filename = $"{DateTime.Now:yyyy-MM-dd hh-mm-ss.ffffff}.log";
            PrintToFile(filename, collection, name);
        }

        private static void PrintToFile<T>(String filename, IEnumerable<T> collection, String name)
        {
            using (TextWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(new String('_', Environment.CommandLine.Length / 2));
                writer.WriteLine("{1}{0}", name, Environment.NewLine);
                foreach (var item in collection)
                    writer.WriteLine(item);
                writer.Flush();
            }
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

        private static void WriteFile<T>(IEnumerable<T> collection, String filename)
        {
            const String pathToFile = @"C:\Users\Людмила\Desktop";
            var path = Path.Combine(pathToFile, filename);
            if (!Path.HasExtension(path))
                path += ".txt";
            using (var file = new StreamWriter(path, true))
                foreach (var item in collection)
                    file.WriteLine(Convert.ToString(item).Replace(",", "."));
        }
    }

}
