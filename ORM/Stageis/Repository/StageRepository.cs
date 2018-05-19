using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;
using ORM.Stageis.Entities;
using ORM.Lines.Entities;
using ORM.Lines.Repository;
using ORM.Stageis.Repository.Limits;
using ORM.OldHelpers;

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
        public static StageRepository GetInstance() => GetInstance<StageRepository>(SessionWrapper.GetInstance().Factory);

        /// <summary>
        /// ID перегона по станции отправления и назначения
        /// </summary>
        /// <param name="arrivalId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Guid GetStageByNameStation(Guid arrivalId, Guid departmentId) => 
            GetAll().SingleOrDefault(st => st.Arrival.ID == arrivalId && st.Departure.ID == departmentId)?.ID 
            ?? throw new ArgumentOutOfRangeException(paramName: nameof(arrivalId));

        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Station GetDepartureByStageId(Guid stageId) => GetAll().SingleOrDefault(stage => stage.ID == stageId)?.Departure;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public Station GetArrivalByStageId(Guid stageId) => GetAll().SingleOrDefault(stage => stage.ID == stageId)?.Arrival;

        /// <summary>
        /// длина перегона
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Double GetStageLength(Guid stageId) => 
            GetAll().SingleOrDefault(stage => stage.ID == stageId)?.Length 
            ?? throw new ArgumentOutOfRangeException($"Illegal stage code ({stageId}).", nameof(stageId));

        /// <summary>
        /// показать номер пути для перегона
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — null.</exception>
        public Int32 GetStageTrack(Guid stageId) => 
            GetAll().SingleOrDefault(stage => stage.ID == stageId)?.Track.Number 
            ?? throw new ArgumentOutOfRangeException($"Illegal stage code ({stageId}).", nameof(stageId));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        public Track GetTrack(Guid stageId) => GetAll().SingleOrDefault(stage => stage.ID == stageId)?.Track;

        /// <summary>
        /// </summary>
        /// <param name="stageId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public IEnumerable<NMLine> GetNMForStage(Guid stageId)
        {
            var track = GetTrack(stageId);
            var trackRepository = TrackRepository.GetInstance();
            var nmLines = trackRepository.GetNMForTrack(track);
            var departure = GetDepartureByStageId(stageId);
            var arrival = GetArrivalByStageId(stageId);

            var result = new SortedList<Double, NMLine>
            {
                {
                    departure.Piketage, new NMLine
                    {
                        Length = 100,
                        Piketage = departure.Piketage,
                        Track = track
                    }
                }
            };


            //едем от меньшего к большему
            var tmp = GetAllPiketagesBetweenStations(nmLines, departure, arrival);
            foreach (var nm in tmp)
                result.Add(nm.Piketage, nm);
      
            result.Add(arrival.Piketage, new NMLine
            {
                Length = 100,
                Piketage = arrival.Piketage,
                Track = track
            });

            return arrival.Piketage < departure.Piketage
                ? result.OrderByDescending(item => item.Key).Select(item => item.Value)
                : result.Values;
        }

        private static IEnumerable<NMLine> GetAllPiketagesBetweenStations(IEnumerable<NMLine> nmLines, Station departure, Station arrival)
        {
            var ascDirection = departure.Piketage < arrival.Piketage;
            var predicate = ascDirection
                ? new Func<NMLine, Boolean>(nm => nm.Piketage.IsIntoRange(departure.Piketage, arrival.Piketage))
                : new Func<NMLine, Boolean>(nm => nm.Piketage.IsIntoRange(arrival.Piketage, departure.Piketage));

            return nmLines.Where(predicate).ToList();
        }

        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public IEnumerable<ILimits> GetAllLimitsForStage(Guid stage)
        {
            var limitStageRepository = LimitStageRepository.GetInstance();
            var limitStage = limitStageRepository.GetLimits(stage);
            var limitSortedStage = new VelocityConvertLimitStage(limitStage);
            var velocityLimits = limitSortedStage.Limits;

            var openStageRepository = OpenStageRepository.GetInstance();
            var openStage = openStageRepository.GetLimits(stage);
            var openSortedStage = new OpenConvertLimitStage(openStage);
            var openSortedLimits = openSortedStage.Limits;

            var asrStageRepository = ASRStageRepository.GetInstance();
            var asrStage = asrStageRepository.GetLimits(stage);
            var asrSortedStage = new ASRConvertLimitStage(asrStage);
            var asrLimits = asrSortedStage.Limits;

            var currentStageRepository = CurrentSectionStageRepository.GetInstance();
            var currentStage = currentStageRepository.GetLimits(stage);
            var currentSortedStage = new CurrentConvertLimits(currentStage);
            var currentSortedLimits = currentSortedStage.Limits;

            var planStageRepository = PlanStageRepository.GetInstance();
            var planStage = planStageRepository.GetLimits(stage);
            var planSortedStage = new PlanConvertedLimitStage(planStage);
            var planLimits = planSortedStage.Limits;

            var profileStageRepository = ProfileStageRepository.GetInstance();
            var profileStage = profileStageRepository.GetLimits(stage);
            var profileSortedStage = new ProfileConvertLimitStage(profileStage);
            var profileLimits = profileSortedStage.Limits;

            var nmStageLimits = GetNMForStage(stage);
            var nmConvertedLimits = new NMConvertLimitStage(nmStageLimits);
            var nmLimits = new NMLimits(nmConvertedLimits.Limits);

            var allVelocityLimits = new AllVelocityLimits(velocityLimits, asrLimits);

            var currentBlockLimits = new CurrentBlockLimits(currentSortedLimits);

            var reliefLimits = new ReliefLimits(planLimits, profileLimits);

            var openLimits = new OpenLimits(openSortedLimits);

            var tmpList = new List<ILimits>
            {
                allVelocityLimits,
                currentBlockLimits,
                reliefLimits,
                openLimits,
                nmLimits
            };

            return tmpList;
        }

        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public IEnumerable<ILimits> GetLimitsWithoutASRStage(Guid stage)
        {
            var limitStageRepository = LimitStageRepository.GetInstance();
            var limitStage = limitStageRepository.GetLimits(stage);
            var limitSortedStage = new VelocityConvertLimitStage(limitStage);
            var velocityLimits = limitSortedStage.Limits;

            var openStageRepository = OpenStageRepository.GetInstance();
            var openStage = openStageRepository.GetLimits(stage);
            var openSortedStage = new OpenConvertLimitStage(openStage);
            var openSortedLimits = openSortedStage.Limits;

            var currentStageRepository = CurrentSectionStageRepository.GetInstance();
            var currentStage = currentStageRepository.GetLimits(stage);
            var currentSortedStage = new CurrentConvertLimits(currentStage);
            var currentSortedLimits = currentSortedStage.Limits;

            var planStageRepository = PlanStageRepository.GetInstance();
            var planStage = planStageRepository.GetLimits(stage);
            var planSortedStage = new PlanConvertedLimitStage(planStage);
            //var planLimits = planSortedStage.Limits;
            var planLimits = planSortedStage.ConvertedPlan();

            var profileStageRepository = ProfileStageRepository.GetInstance();
            var profileStage = profileStageRepository.GetLimits(stage);
            var profileSortedStage = new ProfileConvertLimitStage(profileStage);
            var profileLimits = profileSortedStage.Limits;

            var nmStageLimits = GetNMForStage(stage);
            var nmConvertedLimits = new NMConvertLimitStage(nmStageLimits);
            var nmLimits = new NMLimits(nmConvertedLimits.Limits);

            var allVelocityLimits = new AllVelocityLimits(velocityLimits);

            var currentBlockLimits = new CurrentBlockLimits(currentSortedLimits);

            var reliefLimits = new ReliefLimits(planLimits, profileLimits);

            var openLimits = new OpenLimits(openSortedLimits);

            var tmpList = new List<ILimits>
            {
                allVelocityLimits,
                currentBlockLimits,
                reliefLimits,
                openLimits,
                nmLimits
            };

            return tmpList;
        }



        public override Stage GetByName(String name)
        {
            throw new NotImplementedException();
        }
    }
}