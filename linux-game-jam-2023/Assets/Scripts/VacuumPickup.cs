using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumPickup : MonoBehaviour {
    public string vacuumTag = "Experience";

    public string playerTag = "Player";
    GameObject player;
    Player playerObj;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(playerTag);
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag(playerTag)) {
            foreach (GameObject exp in GameObject.FindGameObjectsWithTag(vacuumTag)) {
                exp.GetComponent<Pickups>().SetFollowPlayer();
            };

            Destroy(this.gameObject);
        }
    }

}
