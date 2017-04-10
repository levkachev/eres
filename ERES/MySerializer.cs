using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using ERES;

public class MySerializer
{
    public MySerializer() { }

    public void SerializeObject(string fileName, SerializableObject objToSerialize)
    {
        FileStream fstream = File.Open(fileName, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fstream, objToSerialize);
        fstream.Close();
    }

    public SerializableObject DeserializeObject(string fileName)
    {
        SerializableObject objToSerialize = null;
        FileStream fstream = File.Open(fileName, FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        objToSerialize = (SerializableObject)binaryFormatter.Deserialize(fstream);
        fstream.Close();
        return objToSerialize;
    }
}
