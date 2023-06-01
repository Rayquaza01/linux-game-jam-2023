using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
    public float speed = 5f;
    public bool followPlayer = false;

    public string playerTag = "Player";
    GameObject player;

    CircleCollider2D col;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag(playerTag);
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (followPlayer) {
            Vector2 heading = player.transform.position - transform.position;
            Vector2 direction = heading / heading.magnitude;

            transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.CompareTag(playerTag)) {
            SetFollowPlayer();
        }
    }

    public void SetFollowPlayer() {
        followPlayer = true;
        col.isTrigger = false;
        col.radius = 0.5f;
    }
}
