using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Songs/FillSong", fileName = "Fill Song")]
public class FillSongSO : SongSO {

    public override void ExecuteSong(float accuracy, bool isPlayer, SingerSO player, SingerSO opponent) {
        AudienceManager audManager = GameObject.Find("AudienceManager").GetComponent<AudienceManager>();
        float initialEffectiveness = this.powerLevel * (accuracy / 100f);
        float singerEffectiveness = EffectivenessManager.getSingerBonus(player, this);
        float opponentEffectiveness = EffectivenessManager.getOpponentBonus(opponent, this);
        if (isPlayer) {
            if (audManager.playerBarFill < 100) {
                int tempFill = Mathf.Clamp(audManager.playerBarFill + Mathf.CeilToInt(initialEffectiveness * ((singerEffectiveness + opponentEffectiveness) / 2f)), 0, 100);
                audManager.playerBarFill = tempFill;
            } else {
                int tempMid = Mathf.Clamp(audManager.midpoint + Mathf.CeilToInt((initialEffectiveness * ((singerEffectiveness + opponentEffectiveness) / 2f)) / 2f), 0, 100);
                audManager.midpoint = tempMid;
            }
        } else {
            if (audManager.opponentBarFill < 100) {
                int tempFill = Mathf.Clamp(audManager.opponentBarFill + Mathf.CeilToInt(initialEffectiveness * ((singerEffectiveness + opponentEffectiveness) / 2f)), 0, 100);
                audManager.opponentBarFill = tempFill;
            } else {
                int tempMid = Mathf.Clamp(audManager.midpoint - Mathf.CeilToInt((initialEffectiveness * ((singerEffectiveness + opponentEffectiveness) / 2f)) / 2f), 0, 100);
                audManager.midpoint = tempMid;
            }
        }
    }
}
