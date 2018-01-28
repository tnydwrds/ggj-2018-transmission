using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private GameObject currentOrb;

    [SerializeField]
    private GameObject nextOrb;

    private float orbOffsetDistance = 0.75f;
    private Vector2 velocity = Vector2.zero;

    void Start() {
        SetLaunchPosition();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            velocity = Vector2.up * moveSpeed;
        }

        if (velocity != Vector2.zero) {
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    void SetLaunchPosition() {
        transform.position = currentOrb.transform.position;

        // Look at netx orb
        Vector2 positionDelta = nextOrb.transform.position - transform.position;
        float zAngle = Mathf.Atan2(positionDelta.y, positionDelta.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);

        transform.Translate(orbOffsetDistance * Vector2.up);
    }

}
