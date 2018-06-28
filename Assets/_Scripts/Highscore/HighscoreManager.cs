using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public enum _data
{
    username,
    score
}

public class HighscoreManager : MonoBehaviour {

    public const string PATH = @"D:\highscore.txt";

    public InputField input;
    public Text scoreText;
    public Text allHighscores;

    public Canvas can1;
    public Canvas can2;


    public static string username;

    private void printHighscores(Highscore hs)
    {
        can1.enabled = false;
        can2.enabled = true;

        hs.Scores.Sort();
        hs.Scores.Reverse();
        string hsText = "";
        foreach(Highscore.HighscoreData hd in hs.Scores)
        {
            hsText += "Highscore: " + hd._highscore + "   Name: " + hd._username;
            hsText += "\r\n";
            //Debug.Log("Name:"+ hd._username + "    Highscore:"+ hd._highscore);
        }
        allHighscores.text = hsText;
    }

    void Start()
    {
        can1.enabled = true;
        can2.enabled = false;
        scoreText.text = "Score:  " + GM.coinTotal;
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



    public void SavePrintHighscore()
    {
        username = input.text;

        SaveHighscore(new Highscore.HighscoreData()
        {
            _highscore = GM.coinTotal,
            _username = username
        });
        printHighscores(ReadHighscores());
    }
}
