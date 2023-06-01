using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5f;
    Rigidbody2D rb;

    public float health = 100f;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += -transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += -transform.right * speed * Time.deltaTime;
        }

        Debug.Log("Health: " + health);
    }

    void OnCollisionStay2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy enemy = c.gameObject.GetComponent<Enemy>();
            health -= enemy.damageRate * Time.deltaTime;
        }
    }
}
