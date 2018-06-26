using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Highscore {
    public List<HighscoreData> Scores = new List<HighscoreData>();

    [Serializable]
    public class HighscoreData
    {
        public float _highscore = 0;
        public string _username = "";
    }
}