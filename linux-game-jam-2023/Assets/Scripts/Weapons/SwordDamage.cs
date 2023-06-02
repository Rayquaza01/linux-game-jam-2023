using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {
    public float damage;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetDamage(float d) {
        damage = d;
    }

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy e = c.gameObject.GetComponent<Enemy>();
            e.ApplyDamage(damage);
        }
    }
}
