using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

    private int currentScreen = 0;

    public GameObject[] screens;

    public void NextScreen(string sceneName) {
        if (currentScreen == screens.Length-1) {
            SceneManager.LoadScene(sceneName);
        } else {
            screens[currentScreen].SetActive(false);
            currentScreen++;
            screens[currentScreen].SetActive(true);
        }
    }

}
