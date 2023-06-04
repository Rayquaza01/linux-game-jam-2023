using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {
    public float cooldown = 1f;
    public float damage = 10f;
    public int amount = 1;

    public bool equipped = false;

    float timer = 0;

    public GameObject projectile;
    AxeProjectile projectileObj;

    public UIManager ui;

    // Start is called before the first frame update
    void Start() {
        projectileObj = projectile.GetComponent<AxeProjectile>();
    }

    public void Upgrade(string type) {
        switch (type) {
            case "COOLDOWN":
                UpgradeCooldown(0.1f);
                break;
            case "DAMAGE":
                UpgradeDamage(5);
                break;
            case "AMOUNT":
                UpgradeAmount(1);
                break;
        }
    }

    public void Equip() {
        equipped = true;
    }

    public void UpgradeCooldown(float amt) {
        cooldown -= amt;
        // ui.SetAxeCooldown(cooldown);
    }

    public void UpgradeDamage(float amt) {
        damage += amt;
        // ui.SetAxeDamage(damage);
    }

    public void UpgradeAmount(int amt) {
        amount += amt;
        // ui.SetAxeAmount(amount);
    }

    // Update is called once per frame
    void Update() {
        if (!equipped) return;

        timer += Time.deltaTime;
        if (timer >= cooldown) {
            for (int i = 0; i < amount; i++) {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            timer = 0;
        }
    }
}
