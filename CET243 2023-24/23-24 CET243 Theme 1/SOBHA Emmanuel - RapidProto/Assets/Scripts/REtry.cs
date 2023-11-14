using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REtry : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
