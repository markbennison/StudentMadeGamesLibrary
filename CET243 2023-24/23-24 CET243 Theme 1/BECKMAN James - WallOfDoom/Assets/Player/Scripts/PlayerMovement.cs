using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private float horizontal;
    private float speed = 8f;
    private float death = -1;

    public Transform bulletSpawn;
    public GameObject bulletprefab;
    public float bulletspeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        var bullet = Instantiate(bulletprefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * bulletspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(collision.gameObject);
       
        transform.position = new Vector2 (0, death);
        death = death + -1;
        if (collision.gameObject.tag.Equals("Finish") == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {

        }



    }
}
