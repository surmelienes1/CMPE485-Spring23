using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour {

	GameObject thedoor;

	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I am not dead");
        if(collision.gameObject.CompareTag("Key"))
        {
			thedoor= GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("open");

            Debug.Log("I am dead");
        }
    }

	private void OnCollisionExit(Collision collision){
		if(collision.gameObject.CompareTag("Key"))
        {
			thedoor= GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("close");
        }
		
	}

}