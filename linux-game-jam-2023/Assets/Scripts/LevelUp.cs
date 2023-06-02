using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelUp : MonoBehaviour {
    public string playerTag = "Player";
    GameObject player;
    Player playerObj;

    public Button maxHealth;
    public Button pierce;
    public Button damage;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(playerTag);
        playerObj = player.GetComponent<Player>();

        maxHealth.onClick.AddListener(UpgradeMaxHealth);
        pierce.onClick.AddListener(UpgradePierce);
        damage.onClick.AddListener(UpgradeDamage);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
    }

    void UpgradeMaxHealth() {
        playerObj.UpgradeMaxHealth(5);
        playerObj.EndLevelUp();
    }

    void UpgradePierce() {
        playerObj.UpgradePierce(1);
        playerObj.EndLevelUp();
    }

    void UpgradeDamage() {
        playerObj.UpgradeDamage(5);
        playerObj.EndLevelUp();
    }
}
