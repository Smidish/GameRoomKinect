using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Highscore {
    public List<HighscoreData> Scores = new List<HighscoreData>();

    [Serializable]
    public class HighscoreData : IComparable<HighscoreData>
    {
        public float _highscore = 0;
        public string _username = "";

        public int CompareTo(HighscoreData other)
        {
            return this._highscore.CompareTo(other._highscore);
        }
    }
}