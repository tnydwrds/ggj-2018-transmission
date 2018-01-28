using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBank : MonoBehaviour {

    [SerializeField]
    private GameObject barrierPrefab;

    [SerializeField]
    [Range(0, 6)]
    private uint barrierCount = 1;

    [SerializeField]
    [Range(45, 360)]
    private float barrierSpreadAngle = 360f;

    private SpriteRenderer overlay;
    private float colorDecrementorAmount = 0.2f;
    private GameObject[] barriers;

    void Start() {
        overlay = GetComponentInChildren<SpriteRenderer>();
        for (var i = 0; i < barrierCount; i++) {
            Quaternion rotation = Quaternion.Euler(0, 0, (barrierSpreadAngle / barrierCount) * i);
            GameObject barrier = Instantiate(barrierPrefab, transform.position, rotation);
            barrier.transform.parent = transform;
        }
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
