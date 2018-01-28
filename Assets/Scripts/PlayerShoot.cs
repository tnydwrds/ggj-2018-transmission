using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private Transform projectileSpawnLocation;

    [SerializeField]
    private float fireRate = 0.3f;

    private GameObject projectile;
    private float nextFireTime = 0f;

    void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime && projectile) {
            nextFireTime = Time.time + fireRate;
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ProjectileDepot") {
            ProjectileDepot depot = other.GetComponent<ProjectileDepot>();
            if (depot) {
                projectile = depot.GetProjectileGameObject();
            }
        }
    }

    void OnTiggerExit2D(Collider2D other) {
        if (other.tag == "ProjectileDepot") {
            projectile = null;
        }
    }

}
