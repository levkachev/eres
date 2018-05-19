using System;

namespace Helpers.IO
{
    public static class Filters
    {
        /// <summary>
        /// Проверка строки на отсутствующее (<see langword="null"/>), пустое или состоящее из одних пробелов значение.
        /// </summary>
        /// <param name="value">Проверяемая строка.</param>
        /// <returns>Результат проверки. <see langword="true"/>, если строка ... </returns>
        public static Boolean IsNullOrEmptyOrWhitespaces(this String value) => String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value);
    }
}
