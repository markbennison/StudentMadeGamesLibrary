using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Transform door;
    public float openAngle = 90.0f; 

    private bool isPlayerOnPlate = false;
    private bool isOpen = false;
    private Quaternion closedRotation; //idk what this does precisely since I got it from stackexchange
    private Quaternion openRotation;
    private float smooth = 2.0f;

    void Start()
    {
        closedRotation = door.rotation;
        openRotation = Quaternion.Euler(0, 0, openAngle) * closedRotation; 
    }

    void Update()
    {
        if (isPlayerOnPlate && Input.GetKeyDown(KeyCode.F)) 
        {
            isOpen = !isOpen;
        }

       
        float t = isOpen ? 1.0f : 0.0f;
        door.rotation = Quaternion.Slerp(closedRotation, openRotation, t);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerOnPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerOnPlate = false;
        }
    }
}
