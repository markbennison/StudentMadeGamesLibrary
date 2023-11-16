using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour {

    public SingerSO singer;
    public MiniGameInitializer miniGameInitializer;
    public PlayerManager player1, player2;
    public Animator animator;

    public GameObject loseScreen;

    public void StartTurnM(AudioSource source) {
        StartCoroutine(StartTurn(source));
    }

    IEnumerator StartTurn(AudioSource source) {
        animator.SetBool("playing", true);
        source.Play();
        yield return new WaitForSeconds(4f);
        source.Stop();
        SongSO song = singer.moves[Random.Range(0, singer.moves.Count)];
        if (Random.Range(0, 2) == 0) {
            song.ExecuteSong(Random.Range(0f, 100f), false, singer, player1.singer);
        } else {
            song.ExecuteSong(Random.Range(0f, 100f), false, singer, player2.singer);
        }
        animator.SetBool("playing", false);
        MiniGameInitializer.turnEnded = false;
        if(!AudienceManager.hasOpponentWon) {
            miniGameInitializer.StartTurn();
        } else {
            loseScreen.SetActive(true);
        }
    }

}
