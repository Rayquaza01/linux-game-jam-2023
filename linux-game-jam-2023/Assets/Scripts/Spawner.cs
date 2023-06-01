using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // enemy to spawn
    public GameObject toSpawn;
    // number of seconds to spawn 1 enemy
    public float spawnFreq = 1;

    float currentTime = 0f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnFreq) {
            Instantiate(toSpawn, transform.position, transform.rotation);
        }
    }
}
