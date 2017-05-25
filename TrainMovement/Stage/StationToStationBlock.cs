using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ORM.Helpers;
using ORM.Lines.Entities;
using ORM.Stageis.Repository;
using ORM.Stageis.Repository.Limits;
using TrainMovement.Train;

namespace TrainMovement.Stage
{
    /// <summary>
    /// Класс перегон, имеющий логику взаимодействия с поездом
    /// </summary>
    public class StationToStationBlock
    {
        /// <summary>
        /// Ссылка на брокер событий
        /// </summary>
        private EventBroker broker;

        /// <summary>
        /// Список всех ограничений
        /// </summary>
        private List<ILimits> limits;

        /// <summary>
        /// 
        /// </summary>
        private Guid current;

        /// <summary>
        /// 
        /// </summary>
        private Track trackNumber;

        /// <summary>
        /// 
        /// </summary>
        private Double stageLength;

        /// <summary>
        /// Список всех ограничений
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        internal IEnumerable<ILimits> Limits
        {
            get { return limits; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                limits = new List<ILimits>(value);
            }
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public Guid CurrentStage {
            get { return current; }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                current = value;
            }
        }

        /// <summary>
        /// Путь
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public Track TrackNumber
        {
            get { return trackNumber; }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                trackNumber = value;
            }
        }

        ///<summary>
        /// Длина перегона
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException" accessor="set">Condition.</exception>
        public Double StageLength
        {
            get { return stageLength; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                stageLength = value;
            }
        }

        /// <summary>
        /// Закрытый конструктор
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        private StationToStationBlock(IEnumerable<ILimits> limits, Guid current, Track track, Double length, EventBroker broker)
        {
            Limits = limits;
            TrackNumber = track;
            StageLength = length;
            CurrentStage = current;
            this.broker = broker;
            Listen();
        }

        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public static StationToStationBlock GetStageWithAllLimits(Guid stage, EventBroker broker)
        {
            var stageRepository = StageRepository.GetInstance();
            var track = stageRepository.GetTrack(stage);
            var length = stageRepository.GetStageLenght(stage);
            

            var limits = stageRepository.GetAllLimitsForStage(stage);
            return new StationToStationBlock(limits, stage, track, length, broker);
        }

        /// <summary>
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public static StationToStationBlock GetStageWithoutASR(Guid stage, EventBroker broker)
        {
            var stageRepository = StageRepository.GetInstance();
            var track = stageRepository.GetTrack(stage);
            var length = stageRepository.GetStageLenght(stage);
            var departer = stageRepository.GetDepartureByIDStage(stage);
            var arrival = stageRepository.GetArrivalByIdStage(stage);

            var limits = stageRepository.GetLimitsWithoutASRStage(stage);
            return new StationToStationBlock(limits, stage, track, length, broker);
        }

        /// <summary>
        /// Выдает максимальную скорость хода по перегону от координаты
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Double GetMaxVelocity(Double space)
        {
            return Limits.OfType<AllVelocityLimits>().First().GetLimit(space);
        }

        /// <summary>
        /// По заданной координате головы  и хвоста возвращает ограничения от уклонов и кривых
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        /// <exception cref="NotImplementedException">Condition.</exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        private IEnumerable<Limit> GetAdditionalLimits(Double head, Double tail)
        {
            return Limits.OfType<ReliefLimits>().First().GetReliefLimitsIn(head, tail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private Limit GetFirstAdditionalLimits(Double head)
        {
            return Limits.OfType<ReliefLimits>().First().GetFirstLimit(head);
        }


        /// <summary>
        /// Рассчитать коэффициент, зависящий от открытых участков для расчета основного сопротивления движения
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public Double GetAerodynamicFactor(Double space)
        {
            return Limits.OfType<OpenLimits>().First().GetLimit(space);
        }

        /// <summary>
        /// Возвращает возможность ехать в тяге (тормозе). Ехать можно в тяге, если поезд не на токоразделе. Метод возвращает true(1). Когда координата совпадает с токоразделом, метод возвращает false(0).
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public Boolean CanPull(Double space)
        {
            var tmp = Limits.OfType<CurrentBlockLimits>().First().GetLimit(space);
            return MathHelper.IsEqual(1, tmp);
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        public Double GetPiketage(Double space)
        {
            return Limits.OfType<NMLimits>().First().GetLimit(space);
        }

        /// <summary>
        /// Подписка на брокер событий
        /// </summary>
        public void Listen()
        {
            broker.Subscribe(new EventHandler(TrainChangingSpace));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainChangingSpace(Object sender, EventArgs e)
        {
            var train = sender as BaseTrain;
            if (train == null || train.CurrentStage != CurrentStage)
                return;
            var space = train.Space;
            train.SpacePiketage = GetPiketage(space);
            train.CanPullOrBreak = CanPull(space);
            
            var trainLength = train.CarLength*train.NumberCars;
            train.ForceAdditionalResistance = GetAdditionalResistance(space, trainLength);
            train.FactorOfOpenStage = GetAerodynamicFactor(space);
            train.MaxVelocity = GetMaxVelocity(space);
        }

        private Double GetAdditionalResistance(Double head, Double trainLength)
        {
            var tail = head - trainLength;
            var result = 0.0;
            Limit firstLimit;
            var releifLimits = GetAdditionalLimits(head, tail).ToList();
            if (releifLimits.Any())
            {
                firstLimit = releifLimits.First();
                foreach (var limit in releifLimits)
                {
                    result += limit.Value*(limit.Space - tail)/trainLength;
                    tail = limit.Space;
                }
            }
            else
                firstLimit = GetFirstAdditionalLimits(head);

            result = result + firstLimit.Value * (head - tail)/ trainLength;
            return result;
        }
    }


}
