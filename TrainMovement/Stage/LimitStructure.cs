using System;

namespace TrainMovement.Stage
{
    /// <summary>
    /// У перегона имеется несколько типов ограничений, таких как ограничения скорости, профиль, план и т.д
    /// Все эти ограничения вида: координата по пути от начала перегона и значение ограничения.
    /// </summary>
    public class LimitStructure : IComparable<LimitStructure>
    {
        /// <summary>
        /// координата по пути от начала перегона
        /// </summary>
        public Double Space;

        /// <summary>
        /// значение ограничения
        /// </summary>
        public Double Limit;

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(LimitStructure lha, LimitStructure rha)
        {
            return lha.Space > rha.Space;
        }

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(LimitStructure lha, LimitStructure rha)
        {
            return !(lha > rha);
        }

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Int32 CompareTo(LimitStructure other)
        {
            if (Math.Abs(this.Space - other.Space) < Double.Epsilon)
                return 0;
            if (this > other)
                return 1;
            return -1;
        }
        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(LimitStructure lha, Double rha)
        {
            return lha.Space > rha;
        }
        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(LimitStructure lha, Double rha)
        {
            return !(lha > rha);
        }
    }
}
