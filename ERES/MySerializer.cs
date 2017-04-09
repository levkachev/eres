using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;

namespace ERES
{
    /// <summary>
    /// 
    /// </summary>
    public class MySerializer
    {
        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="objToSerialize"></param>
        /// <exception cref="ArgumentException">
        ///         <paramref name="path" /> представляет собой строку нулевой
        ///         длины, содержащую только пробелы или один или несколько
        ///         недопустимых символов, как указано 
        ///         <see cref="F:System.IO.Path.GetInvalidPathChars" />. 
        ///         </exception>
        /// <exception cref="SerializationException">Во время сериализации
        /// произошла ошибка, например, если объект в параметре 
        /// <paramref name="graph" /> не отмечен как сериализуемый. </exception>
        /// <exception cref="ArgumentNullException">Свойство <paramref name="serializationStream" /> имеет значение null. -или-Значением параметра <paramref name="graph" /> является null.</exception>
        /// <exception cref="SecurityException">У вызывающего объекта отсутствует необходимое разрешение. </exception>
        public void SerializeObject(String fileName, SerializableObject objToSerialize)
        {
            var fileStream = File.Open(fileName, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, objToSerialize);
            fileStream.Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///         <paramref name="path" /> представляет собой строку нулевой длины, содержащую только пробелы или один или несколько недопустимых символов, как указано <see cref="F:System.IO.Path.GetInvalidPathChars" />. </exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="path" /> имеет значение null. </exception>
        /// <exception cref="PathTooLongException">Длина указанного пути, имени файла или обоих параметров превышает установленное в системе максимальное значение.Например, для платформ на основе Windows длина пути не должна превышать 248 символов, а имена файлов не должны содержать более 260 символов.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///         <paramref name="mode" /> задает недопустимое значение. </exception>
        /// <exception cref="NotSupportedException">
        ///         <paramref name="path" /> имеет недопустимый формат. </exception>
        /// <exception cref="DirectoryNotFoundException">Указанный путь недопустим (например, он соответствует неподключенному диску). </exception>
        /// <exception cref="IOException">При открытии файла возникла ошибка ввода-вывода. </exception>
        /// <exception cref="UnauthorizedAccessException">
        ///         <paramref name="path" /> указывает файл, разрешенный только для чтения.– или – Эта операция не поддерживается на текущей платформе.– или – <paramref name="path" /> определяет каталог.– или – У вызывающего объекта отсутствует необходимое разрешение. – или –<paramref name="mode" /> имеет значение <see cref="F:System.IO.FileMode.Create" />, а указанный файл является скрытым.</exception>
        /// <exception cref="SerializationException">
        ///         <paramref name="serializationStream" /> поддерживает поиск, но его длина равна 0. -или-Целевым типом является тип <see cref="T:System.Decimal" />, однако его значение находится за пределами диапазона типа <see cref="T:System.Decimal" />.</exception>
        /// <exception cref="SecurityException">У вызывающего объекта отсутствует необходимое разрешение. </exception>
        public SerializableObject DeserializeObject(String fileName)
        {
            SerializableObject objToSerialize = null;
            var fileStream = File.Open(fileName, FileMode.Open);
            var binaryFormatter = new BinaryFormatter();
            objToSerialize = (SerializableObject)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return objToSerialize;
        }
    }
}
