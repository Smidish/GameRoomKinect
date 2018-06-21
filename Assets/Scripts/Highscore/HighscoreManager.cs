using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("HighscoresGameRoom")]
public class HighscoreManager {

    [XmlArray("Highscores"), XmlArrayItem("Highscore")]
    public List<Highscore> Highscores = new List<Highscore>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(HighscoreManager));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    public static HighscoreManager Load(string path)
    {
        var serializer = new XmlSerializer(typeof(HighscoreManager));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as HighscoreManager;
        }
    }
    public static HighscoreManager LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(HighscoreManager));
        return serializer.Deserialize(new StringReader(text)) as HighscoreManager;
    }
}


