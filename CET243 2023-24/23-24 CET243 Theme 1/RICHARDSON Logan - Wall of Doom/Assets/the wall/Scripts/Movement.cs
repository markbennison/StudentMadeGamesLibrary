using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Wall;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {


        Wall.AddForce(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
}