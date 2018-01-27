using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 3f;

    void Update() {
        // Movement
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W)) {
            movement = Vector3.up;
        } else if (Input.GetKey(KeyCode.A)) {
            movement = Vector3.left;
        } else if (Input.GetKey(KeyCode.S)) {
            movement = Vector3.down;
        } else if (Input.GetKey(KeyCode.D)) {
            movement = Vector3.right;
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }

}
