using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Base;

namespace ORM.Stageis.Entities
{
    /// <summary>
    /// DTO
    /// </summary>
    public class Stage : Entity<Stage>
    {
        #region Fields
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
        private SortedSet<LimitStructure> automaticSpeedControl;

        /// <summary>
        /// 
        /// </summary>
        private SortedSet<LimitStructure> openSection;

        #endregion


        #region Properties
        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException" accessor="set"><paramref name="value"/> is <see langword="null"/></exception>
        /// <exception cref="ArgumentException" accessor="set">Condition.</exception>
        public String Name
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
        public IEnumerable<LimitStructure> AutomaticSpeedControl
        {
            get { return automaticSpeedControl; }
            protected set { automaticSpeedControl = new SortedSet<LimitStructure>(value); }
        }

        /// <summary>
        /// Ограничения по открытым участкам
        /// </summary>
        public IEnumerable<LimitStructure> OpenSection
        {
            get { return openSection; }
            protected set { openSection = new SortedSet<LimitStructure>(value); }
        }


        #endregion


        /// <summary>
        /// Создание перегона по имени
        /// </summary>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Condition.</exception>
        internal Stage(String stageName, IEnumerable<LimitStructure> speedLimit, IEnumerable<LimitStructure> planLimit, IEnumerable<LimitStructure> profileLimit, IEnumerable<LimitStructure> currentSection, IEnumerable<LimitStructure> automaticSpeedControl, IEnumerable<LimitStructure> openSection)
        {
            Name = stageName;
            SpeedLimit = speedLimit;
            PlanLimit = planLimit;
            ProfileLimit = profileLimit;
            CurrentSection = currentSection;
            AutomaticSpeedControl = automaticSpeedControl;
            OpenSection = openSection;
        }

        /// <summary>
        /// Конструктор для наследования
        /// </summary>
        protected Stage()
        {
        }
    }
}
