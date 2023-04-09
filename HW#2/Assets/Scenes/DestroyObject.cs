using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObject : MonoBehaviour
{

    void Update()
    {
        if(this.transform.position.y <= -10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I am not dead");
        if(collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("I am dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
