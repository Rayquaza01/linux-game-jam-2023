using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    // cooldown in seconds between attacks
    public float cooldown = 2f;
    // damage done to enemy during attack
    public float damage = 10f;

    // amount of time in seconds sword stays out before swapping positions or disappearing
    float lingerCooldown = .2f;
    // state of sword
    //   0 : sword is waiting for cooldown before appearing
    //   1 : cooldown finished! sword has appeared and is waiting for linger cooldown
    //   2 : first swipe done! sword swapped position and is waiting for linger cooldown again
    //   3 : second swipe done! reset to state 0
    float state = 0;

    public GameObject sword;
    SwordDamage swordDamage;

    public bool equipped = false;

    float timer = 0f;

    // Start is called before the first frame update
    void Start() {
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

            if (state > 2) {
                state = 0;
                sword.SetActive(false);
            }
        }
    }

    public void Upgrade(string type) {
        switch (type) {
            case "EQUIP":
                Equip(true);
                break;
            case "DAMAGE":
                UpgradeDamage(5);
                break;
            case "COOLDOWN":
                UpgradeCooldown(0.1f);
                break;
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
