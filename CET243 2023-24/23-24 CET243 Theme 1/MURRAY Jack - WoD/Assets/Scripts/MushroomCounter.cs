using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomCounter : MonoBehaviour
{
    public static MushroomCounter instance;

    public TMP_Text mushroomText;
    public int currentMushrooms = 0;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mushroomText.text = "Mushrooms: " + currentMushrooms.ToString();
    }

    public void IncreaseMushrooms(int v)
    {
        currentMushrooms += v;
        mushroomText.text = "Mushrooms: " + currentMushrooms.ToString();
    }
}
