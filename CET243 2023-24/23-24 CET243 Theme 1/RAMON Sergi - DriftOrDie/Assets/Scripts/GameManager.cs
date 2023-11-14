using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform;

    public float deathZone = -5f;
    public float cameraSpeed = 1.5f;

    void Update()
    {
        float yDifference = player.position.y - cameraTransform.position.y;

        if (yDifference < deathZone)
        {
            RestartGame();
        }

        MoveCameraUp();
    }

    void MoveCameraUp()
    {

        cameraTransform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    }
