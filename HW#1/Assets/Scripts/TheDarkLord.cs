using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDarkLord : MonoBehaviour
{
    // Reference to the Rigidbody component
    public Rigidbody rb;

    // Amount of force to apply to the Rigidbody
    public float forceAmount = 3f;

    // Update is called once per frame
    void Update()
    {
        // Apply a force to move the object to the upper back
        rb.AddForce(new Vector3(0, -forceAmount, 0));
    }
}

