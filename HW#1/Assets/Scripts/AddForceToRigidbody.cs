using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToRigidbody : MonoBehaviour
{
    // Reference to the Rigidbody component
    public Rigidbody rb;

    // Amount of force to apply to the Rigidbody
    public float forceAmount = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // Apply a force to the Rigidbody every frame
        rb.AddForce(Vector3.up * forceAmount);
    }
}

