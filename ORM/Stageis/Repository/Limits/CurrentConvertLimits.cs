using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// Класс, реализующий преобразование списка токоразделов в отсортированное множество токоразделов типа Limit(Double, Double) -> (Координата, 0 - токораздел, 2 - нет)
    /// </summary>
    internal class CurrentConvertLimits : BaseConvertLimit<CurrentSectionStage>
    {
        /// <summary>
        /// Можно ехать в тяге
        /// </summary>
        private const Double canPull = 1;

        /// <summary>
        /// Нельзя ехать в тяге
        /// </summary>
        private const Double cannotPull = 0;

        /// <summary>
        /// На 27.04.2017 максимальная длина введенных перегонов 4500
        /// </summary>
        private const Double maxStageLength = 5000;

        /// <summary>
        /// </summary>
        /// <param name="nativeList"></param>
        /// <exception cref="ArgumentNullException">value is <see langword="null" /></exception>
        public CurrentConvertLimits(IEnumerable<CurrentSectionStage> nativeList) : base(nativeList)
        {
        }

        protected override SortedSet<Limit> SetLimits()
        {
            var resultSortedSet = new SortedSet<Limit>();
            var tmpVector = nativeLimits.ToArray();
            for (var i = 0; i < nativeLimits.Count; ++i)
            {
                var current = tmpVector[i];
                var speedLimit = new Limit(current.Start, canPull);
                resultSortedSet.Add(speedLimit);
                speedLimit = new Limit(current.Finish, cannotPull);
                resultSortedSet.Add(speedLimit);
                speedLimit = new Limit(maxStageLength - current.Finish, canPull);
                resultSortedSet.Add(speedLimit);
            }
            return resultSortedSet;
        }
    }
}
