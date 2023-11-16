using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameInitializer : MonoBehaviour {

    public SongManager playerOneSongManager, playerTwoSongManager;
    public PlayerManager playerOneManager, playerTwoManager;

    public GameObject Player1MoveSelector, Player2MoveSelector;

    public AudioSource playerSource;
    public AudioSource opponentSource;

    public bool hasStarted = false;
    public bool hasP1Finished, hasP2Finished = false;
    public Animator P1Animator, P2Animator;

    public static bool turnEnded = false;

    public GameObject winScreen;

    void Start()
    {
        
    }

    void Update() {
        if(playerOneSongManager.activeSong != null && playerTwoSongManager.activeSong != null && !hasStarted) {
            playerSource.Play();
            this.transform.GetChild(0).gameObject.SetActive(true);
            P1Animator.SetBool("playing", true);
            P2Animator.SetBool("playing", true);
            playerOneSongManager.StartSong();
            playerTwoSongManager.StartSong();
            hasStarted = true;
        }
        if(playerOneSongManager.IsSongFinished()) {
            hasP1Finished = true;
        }
        if (playerTwoSongManager.IsSongFinished()) {
            hasP2Finished = true;
        }
        if (hasP1Finished && hasP2Finished) {
            StartCoroutine(RunSong(opponentSource));
        }
    }

    IEnumerator RunSong(AudioSource source) {
        this.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        playerSource.Stop();
        P1Animator.SetBool("playing", false);
        P2Animator.SetBool("playing", false);
        OpponentManager opponentManager = GameObject.Find("Opponent").GetComponent<OpponentManager>();
        if (playerOneSongManager.activeSong != null && playerTwoSongManager.activeSong != null) {
            playerOneSongManager.activeSong.ExecuteSong(playerOneManager.GetAccuracy(), true, playerOneManager.singer, opponentManager.singer);
            playerTwoSongManager.activeSong.ExecuteSong(playerTwoManager.GetAccuracy(), true, playerTwoManager.singer, opponentManager.singer);
            playerOneSongManager.activeSong = null;
            playerTwoSongManager.activeSong = null;
            playerOneSongManager.hasSongPlayed = false;
            playerTwoSongManager.hasSongPlayed = false;
            hasP1Finished = false;
            hasP2Finished = false;
            turnEnded = true;
            if (!AudienceManager.hasPlayerWon) {
                opponentManager.StartTurnM(source);
            } else {
                winScreen.SetActive(true);
            }
        }
    }

    public void StartTurn() {
        Player1MoveSelector.SetActive(true);
        Player2MoveSelector.SetActive(true);
        hasStarted = false;
    }
}
