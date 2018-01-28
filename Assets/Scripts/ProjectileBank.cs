using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBank : MonoBehaviour {

    private SpriteRenderer overlay;
    private float colorDecrementorAmount = 0.2f;

    void Start() {
        overlay = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Projectile") {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            Color color = overlay.color;
            if (color.a >= 0) {
                color.a -= colorDecrementorAmount;
                this.overlay.color = color;
            }
        }
    }

}
