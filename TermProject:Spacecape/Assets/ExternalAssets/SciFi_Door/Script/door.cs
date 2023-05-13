using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class door : MonoBehaviour {

	GameObject thedoor;

    void Start () {
    }

	private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            
			thedoor= GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("open");

            Destroy(GameObject.FindWithTag("Key"));
        }
    }

}