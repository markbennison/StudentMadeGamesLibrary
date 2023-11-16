using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


    public InputActionAsset asset;
    public InputActionReference moveSelector, confirmSelector;

    public SingerSO singer;

    public AudienceManager.Player player;

    public SongManager songManager;
    Color colour;
    SpriteRenderer spriteRenderer;
    int maxNotes;
    int curNotes;

    private bool pressed = false;

    private void OnEnable() {
        asset.Enable();
        moveSelector.action.Enable();
        confirmSelector.action.Enable();
    }

    void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        colour = spriteRenderer.color;
        if (songManager != null && songManager.activeSong != null) {
            maxNotes = songManager.activeSong.GetLength();
        }
    }

    void Update() {
        Vector2 dirInput = moveSelector.action.ReadValue<Vector2>();
        transform.localPosition = dirInput.normalized;
        float buttonValue = confirmSelector.action.ReadValue<float>();
        if (buttonValue > 0 && !pressed) {
            StartCoroutine(SetColour());
            pressed = true;
        } else if(buttonValue <= 0) {
            pressed = false;
        }
    }

    IEnumerator SetColour() {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = colour;

    }
    
    
    void OnTriggerStay2D(Collider2D other) {
        if (spriteRenderer.color.Equals(Color.red) && Vector3.Distance(other.transform.localPosition, Vector3.zero) > 0.3f) {
            Destroy(other.gameObject);
            curNotes++;
        }
    }

    public int GetAccuracy() {
        return (int)(((float)curNotes / (float)maxNotes) * 100);
    }
}
