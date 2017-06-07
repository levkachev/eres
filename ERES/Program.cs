/**
 * Comment by const_phi.
 */

using System.Collections.Generic;
using System;
using ORM.Energy.Entities;
using ORM.Lines.Entities;
using System.IO;
using System.Linq;
using ORM.Lines.Repository;
using ORM.Stageis.Repository;
using ORM.Trains.Repository;
using TrainMovement;
using TrainMovement.Energy;
using TrainMovement.ModeControl;
using TrainMovement.Stage;
using TrainMovement.Train;


namespace ERES
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public const Double IntegrStep = 0.1;

        //   public static ISessionFactory sessionFactory { get; protected set; }
        static void Main(string[] args)
        {
            //  sessionFactory = SessionFactory.GetSessionFactory();


            /// <summary>
            /// Показать фидеры выбранного типа для выбранной подстанции на выбранной линии
            /// </summary>
            /// 

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

            //var motortypeRepository = MotorTypesRepository.GetInstance();
            //var motortype = motortypeRepository.GetByType("AC");

            //var trainnameRepository = TrainNameRepository.GetInstance();
            //var trainname = trainnameRepository.GetIDByName("81-740.4");

            var massRepository = MassRepository.GetInstance();
            var mass = massRepository.GetByMass(100);

            //var modecontrolRepository = ModeControlsRepository.GetInstance();
            //var modecontrol = modecontrolRepository.GetByModeControl("Pull1");

            //var vfiRepository = VFIRepository.GetInstance();
            //ShowCollection<VFI>(vfiRepository.GetVFI(testTrainName, modecontrol, mass), "GetVFI");

            var nameLine = "Калининская";

            var lineRepository = LineRepository.GetInstance();
            //var PSS = lineRepository.GetAllPowerSupplyStations(nameLine);
            //ShowCollection<PowerSupplyStation>(PSS, "PowerSupplyStations");




            var track = lineRepository.GetAllTrack(nameLine);
            //ShowCollection<Track>(track, "Track");

            var stationRepository = StationRepository.GetInstance();
            var arrival = stationRepository.GetIDByName("Площадь Ильича");
            var department = stationRepository.GetIDByName("Марксистская");
            var stageRepository = StageRepository.GetInstance();
            var stageGuid = stageRepository.GetStageByNameStation(arrival, department);


            var broker = new EventBroker();

            var stage = StationToStationBlock.GetStageWithoutASR(stageGuid, broker);

            ICountVoltage voltage = new SimpleVoltage(broker, 825);

            const String trainName = "81-740.1(Rusi4)";
            var train = TrainFactory.GetACTrain(trainName, broker);
            IModeControl modeControl = TrainMovement.Interpolation.Pull4Rusi4.GetInstance(mass);
            train.Start(stageGuid, 11);
            var move = new List<OutTrainParameters>();
            var step = train.Move(500, modeControl).ToList();
            move.AddRange(step);

            //modeControl = TrainMovement.Interpolation.InertRusi4.GetInstance(mass);
            //step = train.Move(1500, modeControl).ToList();
            //move.AddRange(step);

            //modeControl = TrainMovement.Interpolation.Pull3Rusi4.GetInstance(mass);
            //step = train.Move(2000, modeControl).ToList();
            //move.AddRange(step);

            modeControl = TrainMovement.Interpolation.InertRusi4.GetInstance(mass);
            step = train.Move(1960, modeControl).ToList();
            move.AddRange(step);

            modeControl = TrainMovement.Interpolation.Break2Rusi4.GetInstance(mass);
            step = train.Move(2055, modeControl).ToList();
            move.AddRange(step);

            //modeControl = TrainMovement.Interpolation.InertRusi4.GetInstance(mass);
            //step = train.Move(1765, modeControl).ToList();
            //move.AddRange(step);

            //modeControl = TrainMovement.Interpolation.Break2Rusi4.GetInstance(mass);
            //step = train.Move(2048, modeControl).ToList();
            //move.AddRange(step);

            PrintToFile<OutTrainParameters>(move, "moving");

            //ShowCollection<OutTrainParameters>(move, "moving");
            Console.WriteLine("the end");

            // var length = stageRepository.GetStageLenght(st);
            // Console.WriteLine(Convert.ToString(length), "StageLenght");

            //  var station = lineRepository.GetAllStation(nameLine);
            // //var station = stationRepository.GetLineStationName(nameLine);
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
            // //string nameFile = "StationPiketage";
            // //string format = ".txt";
            // //string path = Path.Combine(pathToFile, nameFile) + format;


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
            //obj.Energy = energyeneregy;

            //MySerializer serializer = new MySerializer();
            ////serializer.SerializeObject("output.txt", obj);
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("output.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, obj);
            //stream.Close();

            //obj = serializer.DeserializeObject("output.txt");
            //energyeneregy = obj.Energy;


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

        private static void PrintToFile<T>(IEnumerable<T> collection, String name)
        {
            var filename = $"{DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss.ffffff")}.log";
            PrintToFile<T>(filename, collection, name);
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

        private static void WriteFile<T>(IEnumerable<T> collection, String nameFile)
        {
            string pathToFile = @"C:\Users\Valeriyа\Desktop";
            string path = Path.Combine(pathToFile, nameFile) + ".txt";
            StreamWriter file = new StreamWriter(path, true);

            foreach (var item in collection)
            {
                file.WriteLine(Convert.ToString(item).Replace(",", "."));
            }
            file.Close();
        }
    }

}
