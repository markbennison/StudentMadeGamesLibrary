using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSO : ScriptableObject {

    public string songName;
    public SongType songType;
    public AudioClip clip;
    public float tempo;
    public int powerLevel;
    [TextArea(10, 50)]
    public string notes;

    public string GetLine(int lineNum) {
        string[] lines = notes.Split('\n');
        return lines[lineNum];
    }

    public int GetLength() {
        string[] lines = notes.Split('\n');
        return lines.Length;
    }

    public virtual void ExecuteSong(float accuracy, bool isPlayer, SingerSO player, SingerSO opponent) {
    }

    public enum SongType {
        Rock,
        Pop
    }

}
