using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public System.DateTime startTime;

    public GameOverScreen GameOverScreen;

    void Start () {
        startTime = System.DateTime.UtcNow;
    }

    void Update()
    {
        if(this.transform.position.y <= -10) {
            Destroy(gameObject);
            GameOverScreen.Setup(0);
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I am not dead");
        if(collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("I am dead");
            Destroy(gameObject);
            GameOverScreen.Setup(0);
        }
    }
}
