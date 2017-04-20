using System;
using System.Collections.Generic;
using System.Linq;
using ORM.Stageis.Entities;


namespace TrainMovement.Stages
{
    /// <summary>
    /// Логика работы с перегоном
    /// </summary>
    public sealed class StageTry: ORM.Stageis.Entities.Stage
    {
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
            for (index = 0; (index < tmpStructure.Count) || (tmpStructure[index] > space); ++index) ;
            return tmpStructure[index].Limit;
        }
    }
}

