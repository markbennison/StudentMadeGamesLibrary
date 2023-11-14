using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interaction : MonoBehaviour
{
    [Header("Detection Parameters")]
    // Detection Point
    public Transform detectionPoint;
    // Detection Radius
    private float detectionRadius;
    // Detection Layer
    public LayerMask detectionLayer;
    // Cached Trigger Object
    public GameObject detectedObject;
    // List of Picked Item
    public List<GameObject> pickeditem = new List<GameObject>();
    //Examine
    public GameObject examineWindow;
    public Text examineText;
    public Image examineImage;
    public bool isExamining;
    // Display coin
    public DisplayCoin Display;

    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }
    
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius,detectionLayer);
        if (obj ==null )
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
        
    }

    public void PickUpItem(GameObject item)
    {
        pickeditem.Add(item);
        Display.CoinAmount++;
    }

    public void ExamineItem(Item item)
    {
        if(isExamining)
        {
            //Hide the examine window
            examineWindow.SetActive(true);
            //disable the boolean
            isExamining = true;
        }
        else
        {
            //Show the item's image in the middle
            examineImage.sprite = GetComponent<SpriteRenderer>().sprite;
            //Write description of text
            examineText.text = item.descriptionText;
            //Display Examine window
            examineWindow.SetActive(false);
            //enable the boolean
            isExamining = false;
        }
    }
}


