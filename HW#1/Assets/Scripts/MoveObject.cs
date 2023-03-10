using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public float speed = 10f; // The speed at which the object moves

    void Update() {
        float horizontal = Input.GetAxis("Horizontal"); // Get the horizontal input
        float vertical = Input.GetAxis("Vertical"); // Get the vertical input

        // Move the object in the direction of the input
        transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    }
}

