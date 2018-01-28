using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Projectile") {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

}
