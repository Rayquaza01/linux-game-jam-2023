using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour {
    public TMP_Text score;
    public Button restart;

    // Start is called before the first frame update
    void Start() {
        restart.onClick.AddListener(Restart);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateScore(float time) {
        score.text = "Score: " + time.ToString() + "s";
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
