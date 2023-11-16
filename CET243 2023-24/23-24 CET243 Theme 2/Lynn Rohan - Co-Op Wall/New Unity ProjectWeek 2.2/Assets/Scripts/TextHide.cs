using UnityEngine;
using UnityEngine.UI;
public class TextHide : MonoBehaviour
{
    public Text UI_Tutorial;
    void Start()
    {
        Invoke("DisableText", 5f);//invoke after 5 seconds
    }
    void DisableText()
    {
        UI_Tutorial.enabled = false;
    }
}
