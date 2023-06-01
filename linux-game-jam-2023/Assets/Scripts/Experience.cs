using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {
    public float exp = 1f;
    public float speed = 5f;
    public bool followPlayer = false;

    public string playerTag = "Player";
    GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(playerTag);
    }

    // Update is called once per frame
    void Update() {
        if (followPlayer) {
            Vector2 heading = player.transform.position - transform.position;
            Vector2 direction = heading / heading.magnitude;

            transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
        }
    }

    public void SetExperience(float e) {
        exp = e;
    }
}
