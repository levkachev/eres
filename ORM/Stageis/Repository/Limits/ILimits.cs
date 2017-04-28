using System;
using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Все ограничения должны иметь свойство IEnumerable(Limit) для чтения и давать значение ограничения по координате.
    /// </summary>
    internal interface ILimits
    {
        /// <summary>
        /// Ограничения.
        /// </summary>
        IEnumerable<Limit> Limits { get; }

        /// <summary>
        /// По заданной координате дать соответствующее ограничение.
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        Double GetLimit(Double space);
    }
}