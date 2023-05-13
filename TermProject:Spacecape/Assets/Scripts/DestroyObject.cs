using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public System.DateTime startTime;

    public GameOverScreen GameOverScreen;

    public GameObject Darwin;

    public GameObject Anais;

    public GameObject Nicole;

    public GameObject Richard;

    public Material otherSkybox; // assign via inspector

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
        if(collision.gameObject.CompareTag("Spike")){
            Destroy(gameObject);
            GameOverScreen.Setup(-2);
        }
        else if(collision.gameObject.CompareTag("Patrick") || collision.gameObject.CompareTag("Carrie") || collision.gameObject.CompareTag("Joanna") || collision.gameObject.CompareTag("Lucy"))
        {
            transform.position = new Vector3(20f, 6.4f, -168f);
            GameOverScreen.Setup(-1);
        }
        else if(collision.gameObject.CompareTag("Penny")){
            if(Darwin == null){
                Darwin = GameObject.FindWithTag("Darwin");
                Darwin.transform.position = new Vector3(25f,5.7f,-178f);
            }
            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("BananaJoe"))
        {
            if(Anais == null){
                Anais = GameObject.FindWithTag("Anais");
                Anais.transform.position = new Vector3(20f,5.3f,-180f);
            }
            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Daisy")){
            if(Nicole == null){
                Darwin = GameObject.FindWithTag("Nicole");
                Darwin.transform.position = new Vector3(15f,6.2f,-182f);
            }
            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Yuki")){
            if(Richard == null){
                Richard = GameObject.FindWithTag("Richard");
                Richard.transform.position = new Vector3(10f,6.4f,-182f);
            }

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Gumball")){

            transform.position = new Vector3(-98f, 9.5f, -78f);

        }
        else if(collision.gameObject.CompareTag("Darwin")){

            transform.position = new Vector3(-180f,9.5f,-146f);

        }
        else if(collision.gameObject.CompareTag("Anais")){

            transform.position = new Vector3(-250f,9.5f,-215f);

        }
        else if(collision.gameObject.CompareTag("Nicole")){

            transform.position = new Vector3(-325f,9.5f,-285f);

        }
        else if(collision.gameObject.CompareTag("Teleport")){
            RenderSettings.skybox = otherSkybox;
            DynamicGI.UpdateEnvironment();
            transform.position = new Vector3(0, 5.4f, 0);
        }
        else if(collision.gameObject.CompareTag("Zombie")){
            Destroy(gameObject);
            GameOverScreen.Setup(-3);
        }

    }
}
