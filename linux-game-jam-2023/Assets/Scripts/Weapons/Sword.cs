using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    // cooldown in seconds between attacks
    public float cooldown = 2f;
    // damage done to enemy during attack
    public float damage = 10f;

    float lingerCooldown = .2f;
    float state = 0;

    public GameObject sword;
    SwordDamage swordDamage;

    public bool equipped = false;

    float timer = 0f;

    // Start is called before the first frame update
    void Start() {
        // this.gameObject.SetActive(false);
        sword.SetActive(false);
        swordDamage = sword.GetComponent<SwordDamage>();
        swordDamage.SetDamage(damage);
    }

    // Update is called once per frame
    void Update() {
        if (!equipped) return;

        timer += Time.deltaTime;
        if (state == 0 && timer >= cooldown) {
            //activate
            sword.SetActive(true);
            state++;
            timer = 0;
            return;
        }

        if ((state == 1 || state == 2) && timer >= lingerCooldown) {
            sword.transform.localPosition *= -1;
            timer = 0;

            state++;

            if (state == 3) {
                state = 0;
                sword.SetActive(false);
            }
        }
    }

    public void Equip(bool e) {
        equipped = e;
    }

    public void UpgradeCooldown(float amt) {
        cooldown -= amt;
    }

    public void UpgradeDamage(float amt) {
        damage += amt;
        swordDamage.SetDamage(damage);
    }
}
