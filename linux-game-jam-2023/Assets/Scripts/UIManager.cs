using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour {
    public TMP_Text health;
    public TMP_Text experience;

    public TMP_Text maxHealth;
    public TMP_Text gunPierce;
    public TMP_Text gunDamage;

    public TMP_Text swordCooldown;
    public TMP_Text swordDamage;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void SetHealth(float h) {
        health.text = "Health: " + h.ToString();
    }

    public void SetExperience(float e) {
        experience.text = "Experience: " + e.ToString();
    }

    public void SetMaxHealth(float h) {
        maxHealth.text = "Max HP: " + h.ToString();
    }

    public void SetGunPierce(int p) {
        gunPierce.text = "Gun Pierce: " + p.ToString();
    }

    public void SetGunDamage(float d) {
        gunDamage.text = "Gun Damage: " + d.ToString();
    }

    public void SetSwordCooldown(float c) {
        swordCooldown.text = "Sword Cooldown: " + c.ToString() + "s";
    }

    public void SetSwordDamage(float d) {
        swordDamage.text = "Sword Damage: " + d.ToString();
    }
}
