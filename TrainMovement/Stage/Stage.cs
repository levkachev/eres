using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stage.Entities;

namespace TrainMovement.Stage
{
    /// <summary>
    /// 
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// </summary>
        private String name;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> speedLimit;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> planLimit;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> profileLimit;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> currentSection;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> automaticSR;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> openSection;


        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentException" accessor="set">Condition.</exception>
        public virtual String Name
        {

            get
            {
                return name;
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (value.Trim().Length > 0)
                    throw new ArgumentException(nameof(value));

                name = value;
            }
        }

        // роловреквл

        /// <summary>
        /// Ограничения скорости
        /// </summary>
        public IEnumerable<LimitStructure> SpeedLimit
        {
            get { return speedLimit; }
            protected set { speedLimit = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по уклонам
        /// </summary>
        public IEnumerable<LimitStructure> PlanLimit
        {
            get { return planLimit; }
            protected set { planLimit = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по кривым
        /// </summary>
        public IEnumerable<LimitStructure> ProfileLimit
        {
            get { return profileLimit; }
            protected set { profileLimit = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по токоразделам
        /// </summary>
        public IEnumerable<LimitStructure> CurrentSection
        {
            get { return currentSection; }
            protected set { currentSection = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по системе АРС
        /// </summary>
        public IEnumerable<LimitStructure> ASR
        {
            get { return automaticSR; }
            protected set { automaticSR = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по открытым участкам
        /// </summary>
        public IEnumerable<LimitStructure> OpenSection
        {
            get { return openSection; }
            protected set { openSection = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Создание перегона по имени
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Condition.</exception>
        internal Stage(String stageName, SpeedLimit speed)
        {
            Name = stageName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stageName"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static Stage GetStage(String stageName, SpeedLimit speed)
        {
            return new Stage(stageName, speed);
        }

        /// <summary>
        /// Возвращает текущий коэффициент сопротивления для открытого участка
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        internal Double GetCoefficientOpenStage(Double space)
        {
            return GetLimit(space, OpenSection);
        }

        /// <summary>
        /// Находит ограничение до указанного пути
        /// <param name="space"></param>
        /// <param name="limitStructure"></param>
        /// <returns></returns>
        private static Double GetLimit(Double space, IEnumerable<LimitStructure> limitStructure)
        {
            var tmpStructure = limitStructure as IList<LimitStructure> ?? limitStructure.ToArray();

            Int32 index;
            for (index = 0; (index < tmpStructure.Count) || (tmpStructure[index] > space); ++index);
            return tmpStructure[index].Limit;
        }
    }
}

