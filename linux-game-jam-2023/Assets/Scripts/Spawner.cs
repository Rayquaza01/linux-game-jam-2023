using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // enemy to spawn
    public GameObject toSpawn;
    Enemy toSpawnObj;
    // number of seconds to spawn 1 enemy
    public float spawnFreq = 1;

    public int experience = 1;
    public float speed = 3;
    public float health = 10;
    public float damageRate = 10;

    public bool active = true;

    float currentTime = 0f;

    // Start is called before the first frame update
    void Start() {
        toSpawnObj = toSpawn.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        if (!active) return;

        currentTime += Time.deltaTime;
        if (currentTime >= spawnFreq) {
            GameObject e = Instantiate(toSpawn, transform.position, transform.rotation);
            Enemy enemy = e.GetComponent<Enemy>();

            float rand = Random.value;

            if (rand <= 0.05f) { // 5% chance of strong enemy
                e.transform.localScale *= 2;
                enemy.SetXP(experience * 5);
                enemy.SetSpeed(speed * 0.5f);
                enemy.SetHealth(health * 10);
                enemy.SetDamageRate(damageRate * 2);
            } else {
                enemy.SetXP(experience);
                enemy.SetSpeed(speed);
                enemy.SetHealth(health);
                enemy.SetDamageRate(damageRate);
            }

            currentTime = 0;
        }
    }

    public void LevelUp() {
        spawnFreq -= 0.1f;

        experience++;
        health += 5;
        damageRate += 1;
    }
}
