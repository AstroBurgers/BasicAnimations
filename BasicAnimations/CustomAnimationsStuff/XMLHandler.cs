using System;
using System.IO;
using System.Xml.Serialization;
using static BasicAnimations.Systems.Logging;

namespace BasicAnimations.CustomAnimationsStuff;

internal class XmlHelper<TE>
{
    internal string FilePath { get; private set; }
    
    internal XmlHelper(string filePath)
    {
        this.FilePath = filePath;
    }

    internal void SerializeXml(TE data)
    {
        var serializer = new XmlSerializer(typeof(TE));
        using(var sw = new StreamWriter(FilePath, false))
        {
            serializer.Serialize(sw, data);
        }
    }

    internal TE DeserializeXml()
    {
        Logger.Log(LogType.Normal,$"Deserializing XML File: {FilePath}");
        var serializer = new XmlSerializer(typeof(TE));
        TE? xmlObject = default;
        using(var fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            try
            {
                xmlObject = (TE)serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                Logger.Log(LogType.Error, $"An error occured in {nameof(DeserializeXml)}, Error: {e}");
            }
        }
        return xmlObject;
    }

    internal bool DoesFileExist()
    {
        return File.Exists(FilePath);
    }

    internal void DeleteFile()
    {
        if(DoesFileExist())
        {
            File.Delete(FilePath);
        }
    }
}