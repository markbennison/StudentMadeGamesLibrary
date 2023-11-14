using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene(sceneName);
    }
}
