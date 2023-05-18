using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SpaceDoor : MonoBehaviour {

	GameObject thedoor;

    public AudioClip doorOpen;

    public bool isCollided = false;

    

    void Start () {
    }

    void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isCollided && other.gameObject.CompareTag("myPlayer"))
        {
            thedoor= GameObject.FindWithTag("SF_DoorSpace");
            thedoor.GetComponent<Animation>().Play("Spaceopen");
            AudioSource.PlayClipAtPoint(doorOpen, other.transform.position);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(isCollided && other.gameObject.CompareTag("myPlayer"))
        {

            thedoor= GameObject.FindWithTag("SF_DoorSpace");
            thedoor.GetComponent<Animation>().Play("Spaceclose");
    
        }
        
    }

}