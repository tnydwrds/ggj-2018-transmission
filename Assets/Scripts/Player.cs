using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private Orb startingOrb;

    private float orbOffsetDistance = 0.75f;
    private Vector2 velocity = Vector2.zero;

    void Start() {
        SetLaunchPosition(startingOrb.transform.position, startingOrb.NextTargetPosition());
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            velocity = Vector2.up * moveSpeed;
        }

        if (velocity != Vector2.zero) {
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Orb") {
            float distance = Vector2.Distance(transform.position, other.gameObject.transform.position);
            if (distance <= 0.3) {
                velocity = Vector2.zero;
                Orb orb = other.GetComponent<Orb>();
                SetLaunchPosition(orb.transform.position, orb.NextTargetPosition());
            }
        }
    }

    void SetLaunchPosition(Vector2 position, Vector2 lookAtTarget) {
        // Look at rotation
        Vector2 positionDelta = lookAtTarget - position;
        float zAngle = Mathf.Atan2(positionDelta.y, positionDelta.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);

        // Position in world space
        transform.position = position;

        // Offset in local space
        transform.Translate(orbOffsetDistance * Vector2.up);
    }

}
