using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {

    public PlayerManager playerManager;
    public AudienceManager audienceManager;
    public List<SongSO> songs;
    public SongSO activeSong;
    public float currentTempo;
    public GameObject upBlock, downBlock, leftBlock, rightBlock;

    public bool isSongPlaying = false;
    public bool hasSongPlayed = false;

    public List<GameObject> allNotes = new();

    public void SetSong(SongSO song) {
        activeSong = song;
        currentTempo = activeSong.tempo / 60f;
    }

    public void StartSong() {
        StartCoroutine(CreateLine());
    }

    IEnumerator CreateLine() {
        hasSongPlayed = false;
        isSongPlaying = true;
        allNotes = new();
        for (int x = 0; x < activeSong.GetLength(); x++) {
            string[] notes = activeSong.GetLine(x).Split();
            for (int i = 0; i < notes.Length; i++) {
                if (notes[i] != "") {
                    Direction direction = (Direction)Enum.ToObject(typeof(Direction), i);
                    GameObject temp = null;
                    switch (direction) {
                        case Direction.UP:
                            temp = Instantiate(upBlock, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity, transform);
                            temp.GetComponent<BlockScript>().songManager = this;
                            allNotes.Add(temp);
                            break;
                        case Direction.DOWN:
                            temp = Instantiate(downBlock, transform.position + new Vector3(0, -2.5f, 0), Quaternion.identity, transform);
                            temp.GetComponent<BlockScript>().songManager = this;
                            allNotes.Add(temp);
                            break;
                        case Direction.LEFT:
                            temp = Instantiate(leftBlock, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity, transform);
                            temp.GetComponent<BlockScript>().songManager = this;
                            allNotes.Add(temp);
                            break;
                        case Direction.RIGHT:
                            temp = Instantiate(rightBlock, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity, transform);
                            temp.GetComponent<BlockScript>().songManager = this;
                            allNotes.Add(temp);
                            break;
                        default:
                            break;
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
        }
        hasSongPlayed = true;
        isSongPlaying = false;
    }

    public bool IsSongFinished() {
        if(hasSongPlayed) {
            bool hasFinsihed = allNotes.Count == activeSong.GetLength();
            allNotes.Clear();
            return hasFinsihed;
        }
        return false;
    }

    public enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
}
