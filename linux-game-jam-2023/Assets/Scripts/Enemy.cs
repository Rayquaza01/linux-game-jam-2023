using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basics of script from
// https://github.com/Rayquaza01/hackysu-2023/blob/main/unity-game/Assets/Enemy.cs

public class Enemy : MonoBehaviour {
    // target enemy should follow
    public string targetTag = "Player";
    GameObject target;

    // amount of experience enemy drops on kill
    public float XPAmount = 1f;
    // amount of health enemy has
    public float health = 10f;
    // amount of damage enemy does to player
    public float damage = 10f;
    // speed enemy should move
    public float speed = 5f;
    // speed enemy should rotate
    public float rotSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindWithTag(targetTag);
    }

    // Update is called once per frame
    void Update() {
        Vector2 heading = target.transform.position - transform.position;
        Vector2 normalized = (heading / heading.magnitude) * speed * Time.deltaTime;

        Quaternion rot = Quaternion.LookRotation(Vector3.forward, heading);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);

        transform.position += new Vector3(normalized.x, normalized.y);
    }
}
