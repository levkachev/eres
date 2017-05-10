using System.Collections.Generic;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Упорядоченная коллеция ограничений
    /// </summary>
    public interface ISortedSetLimits
    {
        /// <summary>
        /// Ограничения.
        /// </summary>
        IEnumerable<Limit> Limits { get; }
    }
}