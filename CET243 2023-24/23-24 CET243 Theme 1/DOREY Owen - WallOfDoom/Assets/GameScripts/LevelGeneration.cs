using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public static GameObject[] levels;

    public Transform cam;
    public GameObject environment;
    public GameObject powerUp;

    private int levelPosition = 0;
    
    void Start()
    {
        levels = Resources.LoadAll<GameObject>("Levels");
    }

    void Update()
    {
        if (cam.position.x > (levelPosition - 3))
        {
            levelPosition += 18;
            GenerateLevel();
        }
    }

    void GenerateLevel()
    {
        int randomLevel = Random.Range(0, levels.Length);

        GameObject level = Instantiate(levels[randomLevel], environment.transform) as GameObject;
        level.transform.position = new Vector3(levelPosition, 0, 0);


        int powerUpX = Random.Range(-9,9);
        int powerUpY = Random.Range(-5,5);

        GameObject newPowerUp = Instantiate(powerUp, level.transform);
        newPowerUp.transform.position = new Vector3((powerUpX + levelPosition), powerUpY, 0);
    }
}
