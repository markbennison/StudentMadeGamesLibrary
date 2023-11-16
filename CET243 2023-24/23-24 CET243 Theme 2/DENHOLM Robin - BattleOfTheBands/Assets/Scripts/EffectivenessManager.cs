using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectivenessManager : MonoBehaviour {

    public static Dictionary<(SongSO.SongType, SingerSO.SingerType), float> typeChart = new Dictionary<(SongSO.SongType, SingerSO.SingerType), float>();

    private void OnEnable() {
        foreach(SongSO.SongType songType in Enum.GetValues(typeof(SongSO.SongType))) {
            foreach(SingerSO.SingerType singerType in Enum.GetValues(typeof(SingerSO.SingerType))) {
                if (songType.Equals(SongSO.SongType.Rock) && singerType.Equals(SingerSO.SingerType.Pop)) {
                    typeChart[(songType, singerType)] = 1.5f;
                } else {
                    typeChart[(songType, singerType)] = 0.5f;
                }
            }
        }
    }


    public static float getSingerBonus(SingerSO singer, SongSO song) {
        SongSO.SongType typeOfSinger = ((SongSO.SongType)((int)singer.singerType));
        if (typeOfSinger.Equals(song.songType)) {
            return 1.25f;
        }
        return 1;
    }

    public static float getOpponentBonus(SingerSO singer, SongSO song) {
        return typeChart[(song.songType, singer.singerType)];
    }

}
