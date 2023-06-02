using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // player's movement speed
    public float speed = 5f;
    Rigidbody2D rb;

    // player's max health
    public float maxHealth = 100f;
    // player's default health
    public float health = 100f;

    // amount of exp orbs player has picked up
    public int experience = 0;
    // player's current level
    public int level = 1;

    // projectile for gun
    public GameObject projectile;

    public UIManager ui;

    public bool paused;


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

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 0) {
                Time.timeScale = 1;
            } else {
                Time.timeScale = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && !paused) {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    public void DamagePlayer(float dmg) {
        health -= dmg;

        ui.SetHealth(health);
    }

    public void HealPlayer(float heal) {
        health += heal;
        if (health >= maxHealth) {
            health = maxHealth;
        }

        ui.SetHealth(health);
    }

    public void TogglePause() {
        SetPause(!paused);
    }

    public void SetPause(bool p) {
        paused = p;
        Time.timeScale = p ? 0 : 1;
    }

    public void AddExperience(int exp) {
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
