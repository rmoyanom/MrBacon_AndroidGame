﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    public string name;
    public int score;
    public int level;

    public SaveData(DirectorGame player)
    {
        score = StaticClass.score;
        level = StaticClass.actualLevel;
    }
}
