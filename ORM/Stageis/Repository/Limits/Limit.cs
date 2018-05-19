using System;
using Helpers.Math;

namespace ORM.Stageis.Repository.Limits
{
    /// <inheritdoc cref="IComparable{T}" />
    /// <summary>
    /// У перегона имеется несколько типов ограничений, таких как ограничения скорости, профиль, план и т.д
    /// Все эти ограничения вида: координата по пути от начала перегона и значение ограничения.
    /// </summary>
    public class Limit : IComparable<Limit>, IEquatable<Limit>
    {
        /// <summary>
        /// координата по пути от начала перегона
        /// </summary>
        public Double Space { get; }

        /// <summary>
        /// значение ограничения
        /// </summary>
        public Double Value { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="value"></param>
        internal Limit(Double space, Double value)
        {
            Space = space;
            Value = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator ==(Limit lha, Limit rha)
        {
            if (ReferenceEquals(lha, rha))
                return true;

            if (lha is null || rha is null)
                return false;

            return lha.Equals(rha);
        }

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator !=(Limit lha, Limit rha) => !(lha == rha);

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(Limit lha, Limit rha) => lha.Space > rha.Space;

        /// <summary>
        /// Сравнение двух ограничений одного типа происходит по пути
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(Limit lha, Limit rha) => lha.Space < rha.Space;

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >=(Limit lha, Limit rha) => !(lha < rha);

        /// <summary>
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <=(Limit lha, Limit rha) => !(lha > rha);

        /// <inheritdoc />
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

        public Boolean Equals(Limit other)
        {
            if (other is null)
                return false;

            return ReferenceEquals(this, other) || Space.IsEqual(other.Space);
        }

        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator >(Limit lha, Double rha) => lha.Space > rha;

        /// <summary>
        /// Сравнение ограничения с числом с плавающей точкой
        /// </summary>
        /// <param name="lha"></param>
        /// <param name="rha"></param>
        /// <returns></returns>
        public static Boolean operator <(Limit lha, Double rha) => lha.Space < rha;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(Object obj) => obj is Limit tmp && Equals(tmp);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (Space.GetHashCode() * 397) ^ Value.GetHashCode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString() => $"<space = {Space}; value = {Value}>";
    }
}