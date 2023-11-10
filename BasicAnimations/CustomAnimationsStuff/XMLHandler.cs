using System;
using System.IO;
using System.Xml.Serialization;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.CustomAnimationsStuff;

internal class XMLHelper<E>
{
    internal string filePath { get; private set; }
    
    internal XMLHelper(string filePath)
    {
        this.filePath = filePath;
    }

    internal void SerializeXML(E data)
    {
        var serializer = new XmlSerializer(typeof(E));
        using(var sw = new StreamWriter(filePath, false))
        {
            serializer.Serialize(sw, data);
        }
    }

    internal E DeserializeXML()
    {
        Logger.Log(LogType.Normal,$"Deserializing XML File: {filePath}");
        var serializer = new XmlSerializer(typeof(E));
        E? xmlObject = default;
        using(var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            try
            {
                xmlObject = (E)serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                Logger.Log(LogType.Error, $"An error occured in {nameof(DeserializeXML)}, Error: {e}");
            }
        }
        return xmlObject;
    }

    internal bool DoesFileExist()
    {
        return File.Exists(filePath);
    }

    internal void DeleteFile()
    {
        if(DoesFileExist())
        {
            File.Delete(filePath);
        }
    }
}