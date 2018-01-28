using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour {

    [SerializeField]
    private Transform targetTransform;

    public Vector2 NextTargetPosition() {
        return targetTransform.position;
    }

}
