using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SpaceDoor : MonoBehaviour {

	GameObject thedoor;

    public GameOverScreen GameOverScreen;

    public System.DateTime startTime;

    void Start () {
        startTime = System.DateTime.UtcNow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {
            thedoor= GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("Spaceopen");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {

            thedoor= GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("Spaceclose");
    
        }
        
    }

}