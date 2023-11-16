using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour {

    [Header("Fetch Settings")]
    [Range(0, 100)]
    public int playerBarFill;
    [Range(0, 100)]
    public int opponentBarFill;
    private int emptyBarFill;
    [SerializeField]
    private float playerPercentage, opponentPercentage, emptyPercentage;
    SpriteRenderer[] spriteRenderers;

    public GameObject playerBar, opponentBar, midpointBar;

    RectTransform playerRect, opponentRect, midpointRect;

    public static bool hasPlayerWon, hasOpponentWon = false;

    System.Random rnd = new System.Random();

    [Header("Retrieve Settings")]
    [Range(0, 100)]
    public int midpoint = 50;

    void Start() {
        spriteRenderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in spriteRenderers) {
            spriteRenderer.flipX = rnd.Next(2) == 0;
        }
        playerRect = playerBar.GetComponent<RectTransform>();
        opponentRect = opponentBar.GetComponent<RectTransform>();
        midpointRect = midpointBar.GetComponent<RectTransform>();
    }

    void Update() {

        int emptyBarFillP = 100 - playerBarFill;
        int emptyBarFillO = 100 - opponentBarFill;
        emptyBarFill = emptyBarFillP + emptyBarFillO;
        playerPercentage = (((float)playerBarFill / (float)(playerBarFill + opponentBarFill + emptyBarFill)) * 100);
        opponentPercentage = (((float)opponentBarFill / (float)(playerBarFill + opponentBarFill + emptyBarFill)) * 100);
        emptyPercentage = 100 - (playerPercentage + opponentPercentage);
        playerRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GetMidpoint(midpoint) * (((float)playerPercentage*2) / 100f));
        opponentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (570-GetMidpoint(midpoint)) * (((float)opponentPercentage*2) / 100f));
        midpointRect.SetLocalPositionAndRotation(new Vector3(GetMidpoint(midpoint-50), 0, 0), Quaternion.identity);
        float percPerAud = 100f / 6f;
        int playerAud = (int)(playerPercentage / percPerAud);
        int oppAud = (int)(opponentPercentage / percPerAud);
        for (int i = 0; i < playerAud; i++) {
            spriteRenderers[i].flipX = true;
        }
        for (int i = 0; i < oppAud; i++) {
            spriteRenderers[5 - i].flipX = false;
        }

        if(midpoint == 100) {
            hasPlayerWon = true;
        }
        if(midpoint == 0) {
            hasOpponentWon = true;
        }
    }

    private int GetMidpoint(int value) {
        return (int)(570 * (value/100f));
    }

    public enum Player {
        PlayerOne,
        PlayerTwo
    }
}
