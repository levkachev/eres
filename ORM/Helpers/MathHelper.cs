using System;

namespace ORM.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class MathHelper
    {
        /// <summary>
        /// Возвращает истина, если два значения равны
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static Boolean IsEqual(Double arg0, Double arg1)
        {
            return Math.Abs(arg0 - arg1) < Double.Epsilon;
        }
    }
}