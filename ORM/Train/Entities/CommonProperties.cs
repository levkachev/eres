using System;
using ORM.Base;


namespace ORM.Train.Entities
{
    public class CommonProperties : Entity<CommonProperties>
    {
        /// <summary>
        /// FLOAT NOT NULL --Длина вагона Lvag
        /// </summary>
        public virtual Double CarLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Double UnladenWeight { get; set; }

        /// <summary>
        /// Масса порожнего вагона tara
        /// </summary>
        public virtual Int32 NumberCars { get; set; }


        /// <summary>
        /// Среднее замедление bsred FLOAT NOT NULL
        /// </summary>

        public virtual Double BreakAverage { get; set; }


        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для тяги wwt1
        /// </summary>
        public virtual Double NetResistancePullFactor { get; set; }


        /// <summary>
        /// FLOAT NOT NULL -- коэффициент аэродинамического сопротивления wwt2
        /// </summary>
        public virtual Double AerodynamicDragFactor { get; set; }


        /// <summary>
        /// FLOAT NOT NULL --1-коэффициент основного сопротивления для выбега wwi1
        /// </summary>
        public virtual Double NetResistanceCoastingFactor1 { get; set; }


        /// <summary>
        /// FLOAT NOT NULL --2-коэффициент основного сопротивления для выбега wwi2
        /// </summary>
        public virtual Double NetResistanceCoastingFactor2 { get; set; }


        /// <summary>
        /// *FLOAT NOT NULL --3-коэффициент основного сопротивления для выбега wwi3
        /// </summary>
        public virtual Double NetResistanceCoastingFactor3 { get; set; }

        /// <summary>
        /// FLOAT NOT NULL -- эквивалентная поверхность состава seq
        /// </summary>
        public virtual Double TrainEquivalentSurface { get; set; }

        /// <summary>
        /// FLOAT --Коэффициент инерции вращающихся масс gamma0
        /// </summary>
        public virtual Double InertiaRotationFactor { get; set; }

        /// <summary>
        /// INT NOT NULL--Удельный расход электроэнергии на собственные нужды Eowne
        /// </summary>
        public virtual Double OwnNeedsElectricPower { get; set; }
    }
}

