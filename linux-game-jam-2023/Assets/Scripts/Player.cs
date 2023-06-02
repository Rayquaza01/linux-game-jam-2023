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
    // amount of exp needed to level up
    public int expThreshold = 10;
    // player's current level
    public int level = 1;

    public UIManager ui;
    public GameObject levelUpUI;

    // weapons
    Gun gun;
    Sword sword;

    public bool paused;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        gun = GetComponent<Gun>();
        sword = GetComponent<Sword>();
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
            TogglePause();
        }

        if (Input.GetMouseButtonDown(0) && !paused) {
            gun.Fire();
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

    public void UpgradeMaxHealth(float amt) {
        maxHealth += amt;
        HealPlayer(amt);

        ui.SetMaxHealth(maxHealth);
    }

    public void UpgradePierce(int amt) {
        gun.UpgradePierce(amt);

        ui.SetPierce(gun.pierce);
    }

    public void UpgradeDamage(float amt) {
        gun.UpgradeDamage(amt);

        ui.SetDamage(gun.damage);
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

        if (experience >= expThreshold) {
            LevelUp();
        }
    }

    public void LevelUp() {
        SetPause(true);
        levelUpUI.SetActive(true);
        level++;
    }

    public void EndLevelUp() {
        levelUpUI.SetActive(false);
        experience -= expThreshold;
        SetPause(false);
    }

    void OnCollisionStay2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy enemy = c.gameObject.GetComponent<Enemy>();
            DamagePlayer(enemy.damageRate * Time.deltaTime);
        }
    }
}
