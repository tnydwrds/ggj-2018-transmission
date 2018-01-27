using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private Transform projectileSpawnLocation;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0.3f;

    private float nextFireTime = 0f;

    void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime) {
            nextFireTime = Time.time + fireRate;
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

}
