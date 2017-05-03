using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Lines.Entities;
using ORM.Lines.Repository;
using ORM.Stageis.Repository.Limits;
using ORM.Helpers;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
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
        /// ID перегона по станции отправления и назначения
        /// </summary>
        /// <param name="arrival"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Guid GetStageByNameStation(Guid arrival, Guid department)
        {
            var tmp = GetAll()
                .Where(st => st.Arrival.ID == arrival)
                .SingleOrDefault(st => st.Departure.ID == department);
            if (tmp == null)
                throw new ArgumentOutOfRangeException(paramName: nameof(arrival));
            return tmp.ID;
        }

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Station GetDepartureByIDStage(Guid stage)
        {
            return GetAll()
                .SingleOrDefault(st => st.ID == stage)
                .Departure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public Station GetArrivalByIdStage(Guid stage)
        {
            return GetAll()
                .SingleOrDefault(st => st.ID == stage)
                .Arrival;
        }

        /// <summary>
        /// длина перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Double GetStageLenght(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Length;
        }

        /// <summary>
        /// показать номер пути для перегона
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Int32 GetStageTrack(Guid stage)
        {
            var tmp = GetAll()
                .SingleOrDefault(st => st.ID == stage);
            return tmp.Track.Tracks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public Track GetTrack(Guid stage)
        {
            return GetAll()
                .SingleOrDefault(st => st.ID == stage)
                .Track;
        }

        /// <summary>
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public IEnumerable<NMLine> GetNMForStage(Guid stage)
        {
            var track = GetTrack(stage);
            var trackRepository = TrackRepository.GetInstance();
            var nmLines = trackRepository.GetNMForTrack(track);
            var departer = GetDepartureByIDStage(stage);
            var arrival = GetArrivalByIdStage(stage);
            
            var result = new SortedList<Double, NMLine>();

            result.Add(departer.Piketage, new NMLine
            {
                Length = 100,
                Piketage = departer.Piketage,
                Track = track
            });

            //едем от меньшего к большему
            var ascDirection = departer.Piketage < arrival.Piketage;

            var predicate = ascDirection
                ? new Func<NMLine, Boolean>(nm =>
                    nm.Piketage >= departer.Piketage &&
                    nm.Piketage <= arrival.Piketage)
                : new Func<NMLine, Boolean>(nm =>
                    nm.Piketage <= departer.Piketage &&
                    nm.Piketage >= arrival.Piketage);

            var tmp = nmLines.Where(predicate).ToList();

            if (!tmp.IsEmpty())
            {
                foreach (var nm in tmp)
                    result.Add(nm.Piketage, nm);
            }
            
            result.Add(arrival.Piketage, new NMLine
            {
                Length = 100,
                Piketage = arrival.Piketage,
                Track = track
            });

            if (arrival.Piketage < departer.Piketage)
            {
                return result.OrderByDescending(item => item.Key).Select(item => item.Value);  
            }
        return result.Values;
        }

        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        internal IEnumerable<ILimits> GetAllLimitsForStage(Guid stage)
        {
            var limitStageRepository = LimitStageRepository.GetInstance();
            var limitStage = limitStageRepository.GetLimits(stage);
            var limitSortedStage = new VelocityConvertLimitStage(limitStage);

            var openStageRepository = OpenStageRepository.GetInstance();
            var openStage = openStageRepository.GetLimits(stage);
            var openSortedStage = new OpenConvertLimitStage(openStage);

            var asrStageRepository = ASRStageRepository.GetInstance();
            var asrStage = asrStageRepository.GetLimits(stage);
            var asrSortedStage = new ASRConvertLimitStage(asrStage);

            var currentStageRepository = CurrentSectionStageRepository.GetInstance();
            var currentStage = currentStageRepository.GetLimits(stage);
            var currentSortedStage = new CurrentConvertLimits(currentStage);

            var planStageRepository = PlanStageRepository.GetInstance();
            var planStage = planStageRepository.GetLimits(stage);
            var planSortedStage = new PlanConvertedLimitStage(planStage);

            var profileStageRepository = ProfileStageRepository.GetInstance();
            var profileStage = profileStageRepository.GetLimits(stage);
            var profileSortedStage = new ProfileConvertLimitStage(profileStage);

            var nmStageLimits = GetNMForStage(stage);
            var nmConvertedLimits = new NMConvertLimitStage(nmStageLimits);
            var nmLimits = new NMLimits(nmConvertedLimits);

            var allVelocityLimits = new AllVelocityLimits(limitSortedStage, asrSortedStage);

            var currentBlockLimits = new CurrentBlockLimits(currentSortedStage);

            var reliefLimits = new ReliefLimits(planSortedStage, profileSortedStage);

            var openLimits = new OpenLimits(openSortedStage);

            var tmpList = new List<ILimits>();
            tmpList.Add(allVelocityLimits);
            tmpList.Add(currentBlockLimits);
            tmpList.Add(reliefLimits);
            tmpList.Add(openLimits);
            tmpList.Add(nmLimits);

            return tmpList;
        }

        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        internal IEnumerable<ILimits> GetLimitsWithoutASRStage(Guid stage)
        {
            var limitStageRepository = LimitStageRepository.GetInstance();
            var limitStage = limitStageRepository.GetLimits(stage);
            var limitSortedStage = new VelocityConvertLimitStage(limitStage);

            var openStageRepository = OpenStageRepository.GetInstance();
            var openStage = openStageRepository.GetLimits(stage);
            var openSortedStage = new OpenConvertLimitStage(openStage);

            var currentStageRepository = CurrentSectionStageRepository.GetInstance();
            var currentStage = currentStageRepository.GetLimits(stage);
            var currentSortedStage = new CurrentConvertLimits(currentStage);

            var planStageRepository = PlanStageRepository.GetInstance();
            var planStage = planStageRepository.GetLimits(stage);
            var planSortedStage = new PlanConvertedLimitStage(planStage);

            var profileStageRepository = ProfileStageRepository.GetInstance();
            var profileStage = profileStageRepository.GetLimits(stage);
            var profileSortedStage = new ProfileConvertLimitStage(profileStage);

            var allVelocityLimits = new AllVelocityLimits(limitSortedStage);

            var currentBlockLimits = new CurrentBlockLimits(currentSortedStage);

            var reliefLimits = new ReliefLimits(planSortedStage, profileSortedStage);

            var openLimits = new OpenLimits(openSortedStage);

            var nmStageLimits = GetNMForStage(stage);
            var nmConvertedLimits = new NMConvertLimitStage(nmStageLimits);
            var nmLimits = new NMLimits(nmConvertedLimits);

            var tmpList = new List<ILimits>();
            tmpList.Add(allVelocityLimits);
            tmpList.Add(currentBlockLimits);
            tmpList.Add(reliefLimits);
            tmpList.Add(openLimits);
            tmpList.Add(nmLimits);

            return tmpList;
        }
    }
}