using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject currentOrb;

    [SerializeField]
    private GameObject nextOrb;

    private float orbOffsetDistance = 0.75f;

    void Start() {
        SetLaunchPosition();
    }

    void SetLaunchPosition() {
        transform.position = currentOrb.transform.position;

        // Look at netx orb
        Vector3 positionDelta = nextOrb.transform.position - transform.position;
        float zAngle = Mathf.Atan2(positionDelta.y, positionDelta.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, zAngle - 90);

        transform.Translate(orbOffsetDistance * Vector3.up);
    }

}
