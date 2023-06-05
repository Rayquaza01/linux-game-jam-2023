using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

// partially based on https://medium.com/swlh/game-dev-how-to-make-health-bars-in-unity-from-beginner-to-advanced-9a1d728d0cbf

public class HudManager : MonoBehaviour {
    public Image healthBar;
    public Image expBar;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateHealthBar(float health, float maxHealth) {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        Debug.Log("Updating health bar");
    }

    public void UpdateExperienceBar(int exp, int expThreshold) {
        expBar.fillAmount = Mathf.Clamp((float) exp / expThreshold, 0, 1);
    }
}
