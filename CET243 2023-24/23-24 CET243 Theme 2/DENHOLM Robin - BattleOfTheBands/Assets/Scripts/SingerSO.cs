using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singer", fileName = "Singer")]
public class SingerSO : ScriptableObject {

    public string singerName;
    public SingerType singerType;
    public List<SongSO> moves;

    public enum SingerType {
        Rock,
        Pop
    }

}
