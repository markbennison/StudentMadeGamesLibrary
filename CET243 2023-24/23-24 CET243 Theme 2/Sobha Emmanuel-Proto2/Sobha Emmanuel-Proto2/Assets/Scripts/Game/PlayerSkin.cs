using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    private int PlayerSkinID;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    
    void Start()
    {
        PlayerSkinID = PlayerPrefs.GetInt("Player1CharID");
        if(PlayerSkinID == 1)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
        }
        if (PlayerSkinID == 2)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
        }
        if (PlayerSkinID == 3)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite3;
        }
        if (PlayerSkinID == 4)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite4;
        }
        if (PlayerSkinID == 5)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite5;
        }
        if (PlayerSkinID == 6)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite6;
        }
        if (PlayerSkinID == 7)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite7;
        }
        if (PlayerSkinID == 8)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite8;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
        }

    }

}
