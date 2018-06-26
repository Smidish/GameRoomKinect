using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum _data
{
    username,
    score
}

public class HighscoreFunctions : MonoBehaviour {

    public const string PATH = @"D:\highscore.txt";

    void Start()
    {
        SaveHighscore(new Highscore.HighscoreData()
        {
            _highscore = 69,
            _username = "Smi"
        });
        Debug.Log(ReadHighscores());
    }

  
    public void SaveHighscore(Highscore.HighscoreData hs)
    {
        var old_hs = ReadHighscores();
        old_hs.Scores.Add(hs);
        string json = JsonUtility.ToJson(old_hs);
        WriteToFile(PATH, json);
    }

    public Highscore ReadHighscores()
    {
        var rawData = ReadFromFile(PATH);
        Highscore highscores = JsonUtility.FromJson<Highscore>(rawData);
        if (highscores == null)
        {
            return new Highscore();
        }
        return highscores;
    }
    
    public void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    public static string ReadFromFile(string filePath)
    {
        string contents = File.ReadAllText(filePath);
        return contents;
    }
}
