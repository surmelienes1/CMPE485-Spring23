using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public System.DateTime startTime;

    public GameOverScreen GameOverScreen;

    public Material otherSkybox; // assign via inspector

    public Material defaultSkybox; // assign via inspector

    public AudioClip newTrack; 

    private AudioManager theAM;

    public GameObject portal;

    public GameObject coinText;

    public AudioClip eatingSound;

    public AudioClip kratosSound;

    void Start () {
        startTime = System.DateTime.UtcNow;
        theAM = FindObjectOfType<AudioManager>();
        portal.SetActive(false);
        coinText.SetActive(false);
        GameObject kratos = GameObject.FindWithTag("Kratos");
        if (kratos != null)
        {
            Vector3 position = kratos.transform.position;
            StartCoroutine(GoW(position));
        }
    }

    IEnumerator GoW(Vector3 position)
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(kratosSound, position);
            yield return new WaitForSeconds(20f);
        }
    }

    void Update()
    {
        if(this.transform.position.y <= -10) {
            Destroy(gameObject);
            GameOverScreen.Setup(0);
        }

        GameObject circleStation = GameObject.FindWithTag("CircleStation");
        if (circleStation != null)
        {
            float dist = Vector3.Distance(transform.position, circleStation.transform.position);
            if(dist < 2f){
                System.TimeSpan ts = System.DateTime.UtcNow - startTime;
                GameOverScreen.Setup(ts.TotalSeconds);
                RenderSettings.skybox = defaultSkybox;
                DynamicGI.UpdateEnvironment();
                transform.position = new Vector3(300f, 197.3f, 297f);
                Debug.Log("Switching music");
                if(newTrack != null)
                {
                    theAM.ChangeBGM(newTrack);
                }
            }
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

            GameObject.FindWithTag("Darwin").transform.position = new Vector3(25f,5.7f,-178f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("BananaJoe")){

            GameObject.FindWithTag("Anais").transform.position = new Vector3(20f,5.3f,-180f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Daisy")){

            GameObject.FindWithTag("Nicole").transform.position = new Vector3(15f,6.2f,-182f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Yuki")){
  
            GameObject.FindWithTag("Richard").transform.position = new Vector3(10f,6.4f,-182f);

            portal.SetActive(true);
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
            coinText.SetActive(true);
            RenderSettings.skybox = otherSkybox;
            DynamicGI.UpdateEnvironment();
            transform.position = new Vector3(0, 5.4f, 0);
        }
        else if(collision.gameObject.CompareTag("Zombie")){
            AudioSource.PlayClipAtPoint(eatingSound, transform.position);
            Destroy(gameObject);
            GameOverScreen.Setup(-3);
        }

    }
}
