using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSelectHandler : MonoBehaviour {

    public GameObject moveNamePrefab;
    public SingerSO singer;
    
    public SongManager songManager;

    public InputActionAsset asset;
    public InputActionReference moveSelector, confirmSelector;

    public GameObject moveSelectorObject;

    public int selectedMoveIndex = 0;

    public bool confirmPressed, upPressed, downPressed = false;

    private void OnEnable() {
        asset.Enable();
        moveSelector.action.Enable();
        confirmSelector.action.Enable();
    }

    private void Awake() {
        selectedMoveIndex = 0;
        for (int i = 0; i < singer.moves.Count; i++) {
            SongSO song = singer.moves[i];
            GameObject moveNameObj = Instantiate(moveNamePrefab, Vector3.zero, Quaternion.identity, transform);
            moveNameObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(15, GetYOffset(i), 0);
            moveNameObj.GetComponent<TMP_Text>().text = $"{song.songName}: ({song.songType} type)";
        }
    }

    void Update() {
        Vector2 dirInput = moveSelector.action.ReadValue<Vector2>();
        if(dirInput.y < 0 && !upPressed) {
            selectedMoveIndex = Mathf.Clamp(selectedMoveIndex+1, 0, singer.moves.Count - 1);
            moveSelectorObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-15, GetYOffset(selectedMoveIndex), 0);
            upPressed = true;
        } else if (dirInput.y == 0) {
            upPressed = false;
        }
        if (dirInput.y > 0 && !downPressed) {
            selectedMoveIndex = Mathf.Clamp(selectedMoveIndex-1, 0, singer.moves.Count-1);
            moveSelectorObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-15, GetYOffset(selectedMoveIndex), 0);
            downPressed = true;
        } else if (dirInput.y == 0) {
            downPressed = false;
        }

        float buttonValue = confirmSelector.action.ReadValue<float>();
        if (buttonValue > 0 && !confirmPressed) {
            songManager.SetSong(singer.moves[selectedMoveIndex]);
            this.gameObject.SetActive(false);
            confirmPressed = true;
        } else if (buttonValue <= 0) {
            confirmPressed = false;
        }
    }

    private float GetYOffset(int lineMultiplier) {
        return -(15 + ((23.9788f + 7) * lineMultiplier));
    }
}
