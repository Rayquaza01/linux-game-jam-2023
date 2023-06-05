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

    public GameObject[] pickups;

    // amount of experience enemy drops on kil;
    public int XPAmount = 1;
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

    public void SetXP(int amt) {
        XPAmount = amt;
    }

    public void SetHealth(float amt) {
        health = amt;
    }

    public void SetSpeed(float amt) {
        speed = amt;
        rotSpeed = amt;
    }

    public void SetDamageRate(float amt) {
        damageRate = amt;
    }

    public void ApplyDamage(float dmg) {
        health -= dmg;
        if (health <= 0) {
            float random = Random.value;


            if (random <= 0.05f) {
                int obj = Random.Range(0, pickups.Length);
                Instantiate(pickups[obj], transform.position, new Quaternion(0, 0, 0, 0));
            } else {
                GameObject e = Instantiate(ExperienceDrop, transform.position, new Quaternion(0, 0, 0, 0));
                // set exp on orb to what enemy is set to drop
                e.GetComponent<Experience>().SetExperience(XPAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
