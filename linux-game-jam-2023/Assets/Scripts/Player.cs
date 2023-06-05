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

    bool levelUpOpen = false;

    List<string> equipped;

    public UIManager ui;
    public HudManager hud;
    public GameObject levelUpUI;

    List<Spawner> spawners = new List<Spawner>();

    // weapons
    Gun gun;
    Sword sword;
    Axe axe;

    public bool paused;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        gun = GetComponent<Gun>();
        sword = GetComponent<Sword>();
        axe = GetComponent<Axe>();

        equipped = new List<string>();

        equipped.Add("Player");
        equipped.Add("Gun");
        if (sword.equipped) equipped.Add("Sword");
        if (axe.equipped) equipped.Add("Axe");

        ui.SetMaxHealth(maxHealth);

        hud.UpdateHealthBar(health, maxHealth);
        hud.UpdateExperienceBar(experience, expThreshold);

        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner")) {
            spawners.Add(spawner.GetComponent<Spawner>());
        }
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

        if (Input.GetKeyDown(KeyCode.Escape) && !levelUpOpen) {
            TogglePause();
        }

        if (Input.GetMouseButtonDown(0) && !paused) {
            gun.Fire();
        }
    }

    public void DamagePlayer(float dmg) {
        health -= dmg;

        hud.UpdateHealthBar(health, maxHealth);
    }

    public void HealPlayer(float heal) {
        health += heal;
        if (health >= maxHealth) {
            health = maxHealth;
        }

        hud.UpdateHealthBar(health, maxHealth);
    }

    public void UpgradeMaxHealth(float amt) {
        maxHealth += amt;
        HealPlayer(amt);

        ui.SetMaxHealth(maxHealth);
    }

    void Upgrade(string type) {
        switch (type) {
            case "MAX_HP":
                UpgradeMaxHealth(5);
                break;
        }
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

        // ui.SetExperience(experience);
        hud.UpdateExperienceBar(experience, expThreshold);

        if (experience >= expThreshold) {
            LevelUp();
        }
    }

    public void LevelUp() {
        SetPause(true);
        levelUpUI.SetActive(true);
        levelUpUI.GetComponent<LevelUp>().RollUpgrades(equipped);
        levelUpOpen = true;

        level++;

        // every 10 levels, scale spawners
        if (level % 10 == 0) {
            foreach (Spawner spawner in spawners) {
                spawner.LevelUp();
            }
        }

    }

    public void EndLevelUp(KeyValuePair<string, string> upgrade) {
        levelUpUI.SetActive(false);
        AddExperience(-expThreshold);

        switch (upgrade.Key) {
            case "Player":
                Upgrade(upgrade.Value);
                break;
            case "Gun":
                gun.Upgrade(upgrade.Value);
                break;
            case "Sword":
                sword.Upgrade(upgrade.Value);
                break;
            case "Axe":
                axe.Upgrade(upgrade.Value);
                break;
        }

        if (upgrade.Value == "EQUIP") {
            equipped.Add(upgrade.Key);
        }

        levelUpOpen = false;

        SetPause(false);
    }

    void OnCollisionStay2D(Collision2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy enemy = c.gameObject.GetComponent<Enemy>();
            DamagePlayer(enemy.damageRate * Time.deltaTime);
        }
    }
}
