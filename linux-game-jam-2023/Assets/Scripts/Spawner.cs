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

            enemy.SetXP(experience);
            enemy.SetSpeed(speed);
            enemy.SetHealth(health);
            enemy.SetDamageRate(damageRate);
            currentTime = 0;
        }
    }
}
