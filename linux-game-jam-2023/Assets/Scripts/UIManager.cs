using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour {
    public TMP_Text health;
    public TMP_Text experience;

    public TMP_Text maxHealth;
    public TMP_Text pierce;
    public TMP_Text damage;

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

    public void SetPierce(int p) {
        pierce.text = "Pierce: " + p.ToString();
    }

    public void SetDamage(float d) {
        damage.text = "Damage: " + d.ToString();
    }
}
