using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KratosMoving : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();

        GetComponent<Rigidbody>().AddForce(movementDirection * speed);
    }
}

