using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
    public float heal = 10f;

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

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag(playerTag)) {
            playerObj.HealPlayer(heal);

            Destroy(this.gameObject);
        }
    }
}
