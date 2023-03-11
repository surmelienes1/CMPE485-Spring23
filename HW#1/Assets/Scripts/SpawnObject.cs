using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    // Reference to the prefab to spawn
    public GameObject prefab;

    // KeyCode for the key to spawn the prefab
    public KeyCode spawnKey = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        // Check if the spawn key is pressed
        if (Input.GetKeyDown(spawnKey))
        {
            // Instantiate the prefab at the current position and rotation
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}

