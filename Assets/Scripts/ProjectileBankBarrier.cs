using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBankBarrier : MonoBehaviour {

    [SerializeField]
    private float speed = 30f;

    private Vector3 rotationPivot;

    void Start() {
        rotationPivot = transform.parent.transform.position;
    }

    void Update() {
        transform.RotateAround(rotationPivot, Vector3.back, -speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Projectile") {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

}
