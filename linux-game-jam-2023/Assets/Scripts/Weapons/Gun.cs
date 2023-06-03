using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject projectile;
    Projectile projectileObj;

    public float damage = 10f;
    public int pierce = 2;

    public UIManager ui;

    // Start is called before the first frame update
    void Start() {
        projectileObj = projectile.GetComponent<Projectile>();
        projectileObj.SetDamage(damage);
        projectileObj.SetPierce(pierce);

        ui.SetGunDamage(damage);
        ui.SetGunPierce(pierce);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Fire() {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    public void Upgrade(string type) {
        Debug.Log("Gun upgrade type " + type);
        switch (type) {
            case "DAMAGE":
                UpgradeDamage(5);
                break;
            case "PIERCE":
                UpgradePierce(1);
                break;
        }
    }

    public void UpgradeDamage(float amt) {
        damage += amt;
        projectileObj.SetDamage(damage);

        Debug.Log("Gun damage at " + damage);
        ui.SetGunDamage(damage);
    }

    public void UpgradePierce(int amt) {
        pierce += amt;
        projectileObj.SetPierce(pierce);

        ui.SetGunPierce(pierce);
    }
}
