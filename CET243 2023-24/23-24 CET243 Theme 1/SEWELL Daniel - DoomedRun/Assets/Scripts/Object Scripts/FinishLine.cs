using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private bool isTriggered = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true; // Sets to true in order to prompt the next scene once the finish line has collided with the player.
            InteractInput();
            Finish();
            Debug.Log("LEVEL COMPLETED!!");
        }
    }
    public void Finish()
    {
        SceneManager.LoadScene("Level 2"); //Next Level
    }

     bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}

