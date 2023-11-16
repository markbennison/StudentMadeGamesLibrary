using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PortalOut;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="P2")
        {
            Destroy(PortalOut);
        }
       

    }
        
    
}
