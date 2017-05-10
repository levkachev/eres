using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stageis.Repository.Limits;
using ORM.Helpers;
using ORM.Lines.Entities;

namespace ORM.Stageis.Repository
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
        private Station departer;

        /// <summary>
        /// 
        /// </summary>
        private Station arrival;

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
        /// Станция отправления
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public Station Departer
        {
            get { return departer; }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                departer = value;
            }
        }

        /// <summary>
        /// Станция прибытия
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        public Station Arrival
        {
            get { return arrival; }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                arrival = value;
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
        private StationToStationBlock(IEnumerable<ILimits> limits, Station departer, Station arrival, Track track, Double length, EventBroker broker)
        {
            Limits = limits;
            Departer = departer;
            Arrival = arrival;
            TrackNumber = track;
            StageLength = length;
            this.broker = broker;
        }

        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public static StationToStationBlock GetStageWithAllLimits(Guid stage, EventBroker broker)
        {
            var stageRepository = StageRepository.GetInstance();
            var track = stageRepository.GetTrack(stage);
            var length = stageRepository.GetStageLenght(stage);
            var departer = stageRepository.GetDepartureByIDStage(stage);
            var arrival = stageRepository.GetArrivalByIdStage(stage);

            var limits = stageRepository.GetAllLimitsForStage(stage);
            return new StationToStationBlock(limits, departer, arrival, track, length, broker);
        }

        /// <summary>
        /// </summary>
        /// <param name="stage"></param>
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
            return new StationToStationBlock(limits, departer, arrival, track, length,broker);
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
        /// По заданной координате рассчитывает дополнительнок сопротивление от клонов и кривых
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        /// <exception cref="NotImplementedException">Condition.</exception>
        /// <exception cref="InvalidOperationException">Исходная последовательность пуста.</exception>
        public Double GetAdditionalResistance(Double space)
        {
            return Limits.OfType<ReliefLimits>().First().GetLimit(space);
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
            broker.SubSuscribe(new EventHandler(TrainChangingSpace));
        }

        private void TrainChangingSpace(Object sender, EventArgs e)
        {
            //var train = sender as Train;
            //if (train == null) return;
            //train.Piketage = GetPiketage();

        }
    }


}
