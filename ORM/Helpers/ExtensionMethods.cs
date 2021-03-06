﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ORM.Helpers
{
    public static class ExtensionMethods
    {
        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public static Boolean IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }
    }
}