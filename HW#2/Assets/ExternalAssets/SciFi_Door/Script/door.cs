using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class door : MonoBehaviour {

	GameObject thedoor;

    public GameOverScreen GameOverScreen;

    public System.DateTime startTime;

    void Start () {
        startTime = System.DateTime.UtcNow;
    }

	private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            
			thedoor= GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("open");

            System.TimeSpan ts = System.DateTime.UtcNow - startTime;

            GameOverScreen.Setup(ts.TotalSeconds);
            Destroy(GameObject.FindWithTag("Key"));
        }
    }

}