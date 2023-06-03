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

    List<string> AllUpgradableItems = new List<string>() {"Player", "Gun", "Sword"};
    Dictionary<string, List<string>> UpgradesByItem = new Dictionary<string, List<string>>() {
        { "Player", new List<string>() { "MAX_HP" } },
        { "Gun", new List<string>() { "DAMAGE", "PIERCE" } },
        { "Sword", new List<string>() { "DAMAGE", "COOLDOWN" } }
    };

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

    // fisher-yates shuffle
    void ShuffleList<t>(List<t> list) {
        System.Random random = new System.Random();

        int n = list.Count;
        for (int i = n - 1; i > 0; i--) {
            int j = random.Next(i + 1);

            t tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }

    public void RollUpgrades(List<string> equipped) {
        List<KeyValuePair<string, string>> options = new List<KeyValuePair<string, string>>();

        // loop through each upgradable item
        foreach (string item in AllUpgradableItems) {
            // if player already has item, add its possible upgrades to the options
            if (equipped.Contains(item)) {
                foreach (string upgrade in UpgradesByItem[item]) {
                    options.Add(new KeyValuePair<string, string>(item, upgrade));
                }
            }
            // if player doesn't have an item equipped, add option to equip it to options
            else {
                options.Add(new KeyValuePair<string, string>(item, "EQUIP"));
            }
        }

        // shuffle the list to choose random upgrades each time
        ShuffleList(options);

        Debug.Log("Start shuffle");
        foreach (KeyValuePair<string, string> i in options) {
            Debug.Log("Possible upgrade is " + i.Key + " " + i.Value);
        }
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
