using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UIManager : MonoBehaviour {
    public TMP_Text health;
    public TMP_Text experience;

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
}
