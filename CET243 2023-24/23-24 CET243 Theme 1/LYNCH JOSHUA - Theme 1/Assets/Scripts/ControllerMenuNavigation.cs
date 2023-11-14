using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerMenuNavigation : MonoBehaviour
{
    private EventSystem eventSystem;
    private GameObject selectedObject;

    private void Start()
    {
        eventSystem = EventSystem.current;

        // Set the initially selected menu item (e.g., the "Start" button)
        selectedObject = eventSystem.firstSelectedGameObject;
    }

    private void Update()
    {
        // Handle controller input for menu navigation
        if (Gamepad.current != null)
        {
            // Use the "Button South" (e.g., A button on an Xbox-like controller) to select menu items
            if (Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                // Check if there's a selected object and if it's a UI button
                if (selectedObject != null && selectedObject.GetComponent<Button>() != null)
                {
                    // Trigger the button's click event
                    selectedObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }

    public void SetSelectedObject(GameObject obj)
    {
        // Set the selected object (called by UI buttons when highlighted)
        selectedObject = obj;
    }
}
