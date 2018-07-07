using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum _data
{
    username,
    score
}


//Klasse kümmert sich um Ausgabe und Speichern des Highscores
public class HighscoreManager : MonoBehaviour {
    public const string PATH = @"D:\highscore.txt";
    public InputField input;
    public Text scoreText;
    public Text allHighscores;
    public Text yourHighscores;
    public Canvas can1;
    public Canvas can2;

    public static string username;

    //Gibt die Highscores aus
    private void printHighscores(Highscore hs)
    {
        can1.enabled = false;
        can2.enabled = true;
        hs.Scores.Sort();
        hs.Scores.Reverse();
        var firstten = hs.Scores.Take(5);
        string hsText = "Highscores \r\n";
        foreach(Highscore.HighscoreData hd in firstten)
        {
            hsText += (hs.Scores.IndexOf(hd)+1)+ ".: " + hd._highscore + "   Name: " + hd._username;
            hsText += "\r\n";
        }
        allHighscores.text = hsText;
        var hs_index = hs.Scores.FindIndex(i => i._username == username);
        if(hs_index >= 4)
        {
            var playerleague = hs.Scores.Skip(hs_index-2).Take(5);
            string playerleaguetext = "\r\n";
            foreach (Highscore.HighscoreData hd in playerleague)
            {
                playerleaguetext += (hs.Scores.IndexOf(hd) + 1) + ".: " + hd._highscore + "   Name: " + hd._username;
                playerleaguetext += "\r\n";
            }
            yourHighscores.text = playerleaguetext;
        } 
    }

    void Start()
    {
        can1.enabled = true;
        can2.enabled = false;
        scoreText.text = "Score:  " + GM.coinTotal;
    }

    //schreibt neuen Highscore ans Ende der json Highscore Datei
    public void SaveHighscore(Highscore.HighscoreData hs)
    {
        var old_hs = ReadHighscores();
        old_hs.Scores.Add(hs);
        string json = JsonUtility.ToJson(old_hs);
        WriteToFile(PATH, json);
    }

    //liest die Highscore classes aus json Datei aus und gibt diese zurück
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
    
    //speichern
    public void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }

    //lesen
    public static string ReadFromFile(string filePath)
    {
        string contents = File.ReadAllText(filePath);
        return contents;
    }


    //speichert neuen Highscore mit eingegebenem Username und ruft die print Funktion auf
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

    public void Change_Scene()
    {
        SceneManager.LoadScene("start");
    }
}
