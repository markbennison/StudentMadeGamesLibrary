using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, Pickup, Examine }
    public InteractionType type;
    //Custom Event
    public UnityEvent customEvent;
    //Examine
    public string descriptionText;
    public Sprite image;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true; // Sets the box collider to true automatically
        gameObject.layer = 8;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Pickup:
                //Add the object to the PickedUpItem List
                Object.FindFirstObjectByType<Interaction>().PickUpItem(gameObject);
                //Delete the object
                gameObject.SetActive(false);
                Debug.Log("PICKED UP");
                break;
                case InteractionType.Examine:
                //Call the Examine item in the interaction system
                Object.FindFirstObjectByType<Interaction>().ExamineItem(this);
                Debug.Log("Examine");
                break;
            default:
                Debug.Log("NULL");
                break;
        }

        //Invoke (call) the custom event.
        customEvent.Invoke();
    }
}
