using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public Vector3 moveDir;
    public SongManager songManager;

    private void FixedUpdate() {
        transform.position += moveDir * (songManager.currentTempo * Time.deltaTime);
    }

    void Update() {
        if (Vector3.Distance(transform.localPosition, Vector3.zero) < 0.05f) {
            Destroy(this.gameObject);
        } else if (Vector3.Distance(transform.localPosition, Vector3.zero) < 0.3f) {
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
