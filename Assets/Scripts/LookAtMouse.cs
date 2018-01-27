using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {

    void Update() {
        // There is probably an easier and more "Unity way" of doing this.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 positionDeleta = mousePosition - transform.position;
        float zAngle = Mathf.Atan2(positionDeleta.y, positionDeleta.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }

}
