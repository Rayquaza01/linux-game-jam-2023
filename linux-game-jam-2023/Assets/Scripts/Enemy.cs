using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basics of script from
// https://github.com/Rayquaza01/hackysu-2023/blob/main/unity-game/Assets/Enemy.cs

public class Enemy : MonoBehaviour {
    // target enemy should follow
    public string targetTag = "Player";
    GameObject target;
    Player targetPlayer;

    public GameObject ExperienceDrop;

    // amount of experience enemy drops on kil;
    public float XPAmount = 1f;
    // amount of health enemy has
    public float health = 10f;
    // amount of damage enemy does to player in a second
    public float damageRate = 10f;
    // speed enemy should move
    public float speed = 5f;
    // speed enemy should rotate
    public float rotSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindWithTag(targetTag);
        targetPlayer = target.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 heading = target.transform.position - transform.position;
        Vector2 normalized = (heading / heading.magnitude) * speed * Time.deltaTime;

        Quaternion rot = Quaternion.LookRotation(Vector3.forward, heading);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);

        transform.position += new Vector3(normalized.x, normalized.y);
    }

    public void ApplyDamage(float dmg) {
        health -= dmg;
        if (health <= 0) {
            Instantiate(ExperienceDrop, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(this.gameObject);
        }
    }
}
