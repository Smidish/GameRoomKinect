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

    private const string DEFAULT_NAME = "";
    private const int DEFAULT_SCORE = 0;

    public string username = DEFAULT_NAME;
    public int score = DEFAULT_SCORE;

    const bool DEBUG_ON = true;

    void Start()
    {
        convertingFunction();
    }

    void convertingFunction()
    {
        var oldjson = File.ReadAllText(@"D:\path.txt");

        Highscore _data = new Highscore();
        _data._highscore = 89;
        _data._username = "Smi";

        //List<Highscore> _data = new List<Highscore>();
        //_data.Add(new Highscore()
        //{
        //    _highscore = 99,
        //    _username = "Smilla"
        //});
        string json = JsonUtility.ToJson(_data);
        json= oldjson + json;
        System.IO.File.WriteAllText(@"D:\path.txt", json);
        Debug.Log(JsonUtility.FromJson<Highscore>(json));
    }

    public static Highscore CreateFromJson(string json)
    {
        return JsonUtility.FromJson<Highscore>(json);
    }

    public void WriteToFile(string filePath)
    {
        // Convert the instance ('this') of this class to a JSON string with "pretty print" (nice indenting).
        string json = JsonUtility.ToJson(this, true);

        // Write that JSON string to the specified file.
        File.WriteAllText(filePath, json);

        // Tell us what we just wrote if DEBUG_ON is on.
        if (DEBUG_ON)
            Debug.LogFormat("WriteToFile({0}) -- data:\n{1}", filePath, json);
    }

    public static HighscoreFunctions ReadFromFile(string filePath)
    {
        // If the file doesn't exist then just return the default object.
        if (!File.Exists(filePath))
        {
            Debug.LogErrorFormat("ReadFromFile({0}) -- file not found, returning new object", filePath);
            return new HighscoreFunctions();
        }
        else
        {
            // If the file does exist then read the entire file to a string.
            string contents = File.ReadAllText(filePath);

            // If debug is on then tell us the file we read and its contents.
            if (DEBUG_ON)
                Debug.LogFormat("ReadFromFile({0})\ncontents:\n{1}", filePath, contents);

            // If it happens that the file is somehow empty then tell us and return a new SaveData object.
            if (string.IsNullOrEmpty(contents))
            {
                Debug.LogErrorFormat("File: '{0}' is empty. Returning default SaveData");
                return new HighscoreFunctions();
            }

            // Otherwise we can just use JsonUtility to convert the string to a new SaveData object.
            return JsonUtility.FromJson<HighscoreFunctions>(contents);
        }
    }







    //public string _name = "Smilla";
    //public int score = 69;

    //void Save()
    //{
    //    Highscore saveData = new Highscore();
    //    saveData._username = "Smi3";
    //    saveData._highscore = 20;

    //    //Convert to Json
    //    string jsonData = JsonUtility.ToJson(saveData);
    //    //Save Json string
    //    PlayerPrefs.SetString("MySettings", jsonData);
    //    PlayerPrefs.Save();
    //}

    //void Load()
    //{
    //    //Load saved Json
    //    string jsonData = PlayerPrefs.GetString("MySettings");
    //    //Convert to Class
    //    Highscore loadedData = JsonUtility.FromJson<Highscore>(jsonData);

    //    //Display saved data
    //    Debug.Log("Username: " + loadedData._username);
    //    Debug.Log("High Score: " + loadedData._highscore);

    //    Debug.Log("IDCount"+loadedData.ID.Count);
    //    for (int i = 0; i < loadedData.ID.Count; i++)
    //    {
    //        Debug.Log("ID: " + loadedData.ID[i]);
    //    }
    //    for (int i = 0; i < loadedData.username.Count; i++)
    //    {
    //        Debug.Log("Username: " + loadedData.username[i]);
    //    }
    //    for (int i = 0; i < loadedData.score.Count; i++)
    //    {
    //        Debug.Log("Score: " + loadedData.score[i]);
    //    }
    //}
}
