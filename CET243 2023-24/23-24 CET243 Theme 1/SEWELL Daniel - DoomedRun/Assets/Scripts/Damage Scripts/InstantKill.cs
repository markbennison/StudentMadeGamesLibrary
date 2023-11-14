using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InstantKill : MonoBehaviour
{
    private bool isTriggered = false;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
     
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // This method is called when another object with a Rigidbody2D component collides with the trap.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall") && !isTriggered)
        {
            isTriggered = true; // Set the trap to triggered so that it doesn't kill the player again
            Debug.Log("You have died!");
            Die();
            SceneManager.LoadScene("Retry");
        }
    }




}





