using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Collections.Generic;

namespace TrainMovement.Stuff
{
    internal static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("Type must be serializable");
            if (ReferenceEquals(self, null))
                return default(T);
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="key" /> имеет значение null.</exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в <see cref="T:System.Collections.Generic.SortedList`2" />.</exception>
        public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(this IEnumerable<TValue> collection, Func<TValue, TKey> keyExtractor)
        {
            var result = new SortedList<TKey, TValue>();
            foreach (var item in collection)
            {
                var current = item;
                result.Add(keyExtractor(current), current);
            }
            return result;
        }
    }
}
