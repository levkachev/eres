using System;
using System.Collections.Generic;

namespace TrainMovement.Stage
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Stage
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
        

     //   public IEnumerable<LimitStructure> SpeedLimit
     //   {
     //       get { return speedLimit; }
     //       private set { speedLimit = value; }
     //   }

        /// <summary>
        /// Ограничения по уклонам
        /// </summary>
        public IEnumerable<LimitStructure> PlanLimit { get; set; }

        /// <summary>
        /// Ограничения по кривым
        /// </summary>
        public IEnumerable<LimitStructure> ProfileLimit { get; set; }

        /// <summary>
        /// Ограничения по токоразделам
        /// </summary>
        public IEnumerable<LimitStructure> CurrentSection { get; set; }

        /// <summary>
        /// Ограничения по системе АРС
        /// </summary>
        public IEnumerable<LimitStructure> ASR { get; set; }

        /// <summary>
        /// Ограничения по открытым участкам
        /// </summary>
        public IEnumerable<LimitStructure> OpenSection { get; set; }

        /// <summary>
        /// Создание перегона по имени
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">Condition.</exception>
        internal Stage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public Double GetForceAdditionalResistance(Train.Train train)
        {
            return 0;
        }
    }
}

