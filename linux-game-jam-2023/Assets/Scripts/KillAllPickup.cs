using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllPickup : MonoBehaviour {
    public string playerTag = "Player";

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag(playerTag)) {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                Enemy e = enemy.GetComponent<Enemy>();
                e.ApplyDamage(e.health);
            }

            Destroy(this.gameObject);
        }
    }
}
