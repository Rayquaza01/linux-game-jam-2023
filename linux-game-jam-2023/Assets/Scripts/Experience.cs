using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {
    public float exp = 1f;

    public string playerTag = "Player";
    GameObject player;
    Player playerObj;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(playerTag);
        playerObj = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void SetExperience(float e) {
        exp = e;
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag(playerTag)) {
            playerObj.AddExperience(exp);
            Destroy(this.gameObject);
        }
    }

}
