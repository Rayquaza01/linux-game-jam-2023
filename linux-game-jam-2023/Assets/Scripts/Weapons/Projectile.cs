using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// basics of script from
// https://github.com/Rayquaza01/hackysu-2023/blob/main/unity-game/Assets/Projectile.cs

public class Projectile : MonoBehaviour {
    // damage projectile does
    public float damage = 10f;
    // number of enemies to pierce
    public int pierce = 2;
    int pierceCount = 0;

    public float speed = 5f;
    Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        Destroy(this.gameObject, 5);

        Vector2 heading = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = (heading / heading.magnitude) * speed;

        //https://answers.unity.com/questions/1860902/rotate-towards-an-object-in-2d.html
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, heading);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
    }

    public void SetPierce(int p) {
        pierce = p;
    }

    public void SetDamage(float d) {
        damage = d;
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Enemy e = c.gameObject.GetComponent<Enemy>();
            e.ApplyDamage(damage);

            pierceCount++;
            if (pierceCount >= pierce) {
                Destroy(this.gameObject);
            }
        }
    }
}
