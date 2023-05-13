using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SpaceDoor : MonoBehaviour {

	GameObject thedoor;

    void Start () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {
            thedoor= GameObject.FindWithTag("SF_DoorSpace");
            thedoor.GetComponent<Animation>().Play("Spaceopen");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("myPlayer"))
        {

            thedoor= GameObject.FindWithTag("SF_DoorSpace");
            thedoor.GetComponent<Animation>().Play("Spaceclose");
    
        }
        
    }

}