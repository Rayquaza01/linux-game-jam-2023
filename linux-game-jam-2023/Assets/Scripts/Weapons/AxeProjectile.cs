using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour {
    public float damage = 10f;
    public float speed = 1f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);

        Vector2 direction = new Vector2((Random.value - 0.5f) * 2, 1);
        Vector2 force = (direction / direction.magnitude) * speed;

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update() {
    }

    public void SetDamage(float amt) {
        damage = amt;
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy e = c.gameObject.GetComponent<Enemy>();
            e.ApplyDamage(damage);
        }
    }
}
