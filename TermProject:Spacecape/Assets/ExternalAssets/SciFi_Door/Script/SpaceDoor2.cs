using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SpaceDoor2 : MonoBehaviour {

	GameObject thedoor;

    public GameOverScreen GameOverScreen;

    void Start () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {
            thedoor= GameObject.FindWithTag("SF_Door2");
            thedoor.GetComponent<Animation>().Play("Spaceopen");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {

            thedoor= GameObject.FindWithTag("SF_Door2");
            thedoor.GetComponent<Animation>().Play("Spaceclose");
    
        }
        
    }

}