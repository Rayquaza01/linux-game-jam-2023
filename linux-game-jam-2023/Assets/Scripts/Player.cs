using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5f;
    Rigidbody2D rb;

    public float health = 100f;

    public float experience = 0f;

    public UIManager ui;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        ui = GameObject.FindWithTag("UI").GetComponent<UIManager>();
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
    }

    public void DamagePlayer(float dmg) {
        health -= dmg;

        ui.SetHealth(health);
    }

    public void HealPlayer(float heal) {
        health += heal;
        if (health >= 100f) {
            health = 100f;
        }

        ui.SetHealth(health);
    }

    public void AddExperience(float exp) {
        experience += exp;

        ui.SetExperience(experience);
    }

    void OnCollisionStay2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy enemy = c.gameObject.GetComponent<Enemy>();
            DamagePlayer(enemy.damageRate * Time.deltaTime);
        }
    }
}