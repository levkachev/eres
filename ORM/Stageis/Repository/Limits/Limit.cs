using System;
using ORM.Helpers;

namespace ORM.Stageis.Repository.Limits
{
    /// <summary>
    /// У перегона имеется несколько типов ограничений, таких как ограничения скорости, профиль, план и т.д
    /// Все эти ограничения вида: координата по пути от начала перегона и значение ограничения.
    /// </summary>
    public class Limit : IComparable<Limit>
    {
        /// <summary>
        /// координата по пути от начала перегона
        /// </summary>
        private readonly Double space;

        /// <summary>
        /// значение ограничения
        /// </summary>
        private readonly Double value;

        /// <summary>
        /// координата по пути от начала перегона
        /// </summary>
        internal Double Space => space;

        /// <summary>
        /// значение ограничения
        /// </summary>
        internal Double Value => value;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="aValue"></param>
        internal Limit(Double space, Double aValue)
        {
            this.space = space;
            value = aValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator ==(Limit lha, Limit rha)
        {
            if (ReferenceEquals(lha, null) || ReferenceEquals(rha, null))
                return false;

            return Math.Abs(lha.Space - rha.Space) < Double.Epsilon;
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator !=(Limit lha, Limit rha)
        {
            return !(lha == rha);
        }

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(Limit lha, Limit rha)
        {
            return lha.Space > rha.Space;
        }

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(Limit lha, Limit rha)
        {
            return lha.Space < rha.Space;
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >=(Limit lha, Limit rha)
        {
            return !(lha < rha);
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <=(Limit lha, Limit rha)
        {
            return !(lha > rha);
        }

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Int32 CompareTo(Limit other)
        {
            if (this > other)
                return 1;
            if (this < other)
                return -1;
            return 0;
        }

        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(Limit lha, Double rha)
        {
            return lha.Space > rha;
        }

        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(Limit lha, Double rha)
        {
            return lha.Space < rha;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(Object obj)
        {
            var tmp = obj as Limit;
            if (tmp == null)
                return false;

            if (ReferenceEquals(this, tmp))
                return true;

            return MathHelper.IsEqual(Space, tmp.Space);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }

        public override String ToString()
        {
            return $"<space = {Space}; value = {Value}>";
        }
    }
}