﻿using System;
using ORM.Base;
namespace ORM.Energy.Entities
{
    /// <summary>
    /// Справочник выпрямителей
    /// </summary>
    public class Diod : Entity<Diod>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public virtual String Name { get; set; }

        /// <summary>
        /// Пороговое напряжение кремниевого вентиля
        /// </summary>
        public virtual Double U0 { get; set; }

        /// <summary>
        /// Активное сопротивление вентильных групп min
        /// </summary>
        public virtual Double Rdmin { get; set; }

        /// <summary>
        /// Активное сопротивление вентильных групп max
        /// </summary>
        public virtual Double Rdmax { get; set; }
    }
}
