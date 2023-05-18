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

    public AudioClip earthTrack;

    private AudioManager theAM;

    public GameObject portal;

    public GameObject spacePortal;

    public GameObject coinText;

    public AudioClip eatingSound;

    public AudioClip kratosSound;

    public AudioClip starWarsSound;

    public AudioClip groguSound;

    public AudioClip samuraiJackSound;

    public AudioClip matrixSound;

    SpaceDoor SpaceDoor;
    
    SpaceDoor2 SpaceDoor2;

    SpaceDoor3 SpaceDoor3;

    SpaceDoor4 SpaceDoor4;

    bool hasStarted = false;

    bool hasStartedKratos = false;

    bool hasStartedSamurai = false;

    bool hasStartedMatrix = false;

    bool hasWon = false;

    IEnumerator co;

    IEnumerator co2;

    IEnumerator co3;

    IEnumerator co4;

    void Start () {

        SpaceDoor = GameObject.FindWithTag("Door1").GetComponent<SpaceDoor>();

        SpaceDoor2 = GameObject.FindWithTag("Door2").GetComponent<SpaceDoor2>();

        SpaceDoor3 = GameObject.FindWithTag("Door3").GetComponent<SpaceDoor3>();

        SpaceDoor4 = GameObject.FindWithTag("Door4").GetComponent<SpaceDoor4>();

        startTime = System.DateTime.UtcNow;
        theAM = FindObjectOfType<AudioManager>();
        portal.SetActive(false);
        coinText.SetActive(false);
        spacePortal.SetActive(false);

        co = StarWars();
        co2 = GoW();
        co3 = SamuraiJack();
        co4 = Matrix();
    }

    IEnumerator GoW()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(kratosSound, new Vector3(296f, 200f, 255f));
            yield return new WaitForSeconds(20f);
        }
    }

    IEnumerator StarWars()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(starWarsSound, new Vector3(296f, 200f, 294f));
            yield return new WaitForSeconds(43f);
        }
    }

    IEnumerator SamuraiJack()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(samuraiJackSound, new Vector3(322f, 200f, 294f));
            yield return new WaitForSeconds(43f);
        }
    }

    IEnumerator Matrix()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(matrixSound, new Vector3(322f, 200f, 255f));
            yield return new WaitForSeconds(117f);
        }
    }

    void Update()
    {
        GameObject darthVader = GameObject.FindWithTag("DarthVader");
        if(darthVader != null){
            if(transform.position.x <= 296  && !hasStarted){
                StartCoroutine(co);
                hasStarted = true;
            }
        }

        GameObject kratos = GameObject.FindWithTag("Kratos");
        if(kratos != null){
            if(transform.position.x <= 296  && !hasStartedKratos && transform.position.z <= 260){
                StartCoroutine(co2);
                hasStartedKratos = true;
            }
        }
        
        GameObject samuraiJack = GameObject.FindWithTag("SamuraiJack");
        if(samuraiJack != null){
            if(transform.position.x >= 322  && !hasStartedSamurai){
                StartCoroutine(co3);
                hasStartedSamurai = true;
            }
        }

        GameObject neo = GameObject.FindWithTag("Neo");
        if(neo != null){
            if(transform.position.x >= 322  && !hasStartedMatrix && transform.position.z <= 260){
                StartCoroutine(co4);
                hasStartedMatrix = true;
            }
        }

        if(this.transform.position.y <= -10) {
            Destroy(gameObject);
            GameOverScreen.Setup(0);
        }

        GameObject circleStation = GameObject.FindWithTag("CircleStation");
        if (circleStation != null)
        {
            float dist = Vector3.Distance(transform.position, circleStation.transform.position);
            if(dist < 2f){
                RenderSettings.skybox = defaultSkybox;
                DynamicGI.UpdateEnvironment();
                transform.position = new Vector3(318f, 197.3f, 263f);
                if(!hasWon){
                System.TimeSpan ts = System.DateTime.UtcNow - startTime;
                GameOverScreen.Setup(ts.TotalSeconds);
                GameObject.FindWithTag("Gumball").transform.localScale -= new Vector3(1, 1, 1);
                GameObject.FindWithTag("Gumball").transform.position = new Vector3(323f, 198.65f, 253f);
                GameObject.FindWithTag("Darwin").transform.localScale -= new Vector3(1, 1, 1);
                GameObject.FindWithTag("Darwin").transform.position = new Vector3(320.5f, 198.4f, 253f);
                GameObject.FindWithTag("Anais").transform.localScale -= new Vector3(1, 1, 1);
                GameObject.FindWithTag("Anais").transform.position = new Vector3(318f, 198.2f, 252f);
                GameObject.FindWithTag("Nicole").transform.localScale -= new Vector3(1, 1, 1);
                GameObject.FindWithTag("Nicole").transform.position = new Vector3(315.5f, 199.2f, 253f);
                GameObject.FindWithTag("Richard").transform.localScale -= new Vector3(1, 1, 1);
                GameObject.FindWithTag("Richard").transform.position = new Vector3(313f, 199.4f, 254f);
                if(newTrack != null)
                {
                    theAM.ChangeBGM(newTrack);
                }
                }
                hasWon = true;
            }
        }

        GameObject circleSpaceStation = GameObject.FindWithTag("CircleSpaceStation");
        if (circleSpaceStation != null)
        {
            float dist = Vector3.Distance(transform.position, circleSpaceStation.transform.position);
            if(dist < 3f){
                coinText.SetActive(true);
                RenderSettings.skybox = otherSkybox;
                DynamicGI.UpdateEnvironment();
                transform.position = new Vector3(0, 5.4f, 0);
                if(!hasWon){
                if(earthTrack != null)
                {
                    theAM.ChangeBGM(earthTrack);
                }
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

            if(!hasWon)
            GameObject.FindWithTag("Darwin").transform.position = new Vector3(25f,5.7f,-178f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("BananaJoe")){

            if(!hasWon)
            GameObject.FindWithTag("Anais").transform.position = new Vector3(20f,5.3f,-180f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Daisy")){

            if(!hasWon)
            GameObject.FindWithTag("Nicole").transform.position = new Vector3(15f,6.2f,-182f);

            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Yuki")){
  
            if(!hasWon)
            GameObject.FindWithTag("Richard").transform.position = new Vector3(10f,6.4f,-182f);

            portal.SetActive(true);
            transform.position = new Vector3(20f, 6.4f, -168f);
        }
        else if(collision.gameObject.CompareTag("Gumball")){

            transform.position = new Vector3(-98f, 9.5f, -78f);

            if(hasWon){
                RenderSettings.skybox = otherSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        else if(collision.gameObject.CompareTag("Darwin")){

            transform.position = new Vector3(-180f,9.5f,-146f);
            if(hasWon){
                RenderSettings.skybox = otherSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        else if(collision.gameObject.CompareTag("Anais")){

            transform.position = new Vector3(-250f,9.5f,-215f);
            if(hasWon){
                RenderSettings.skybox = otherSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        else if(collision.gameObject.CompareTag("Nicole")){

            transform.position = new Vector3(-325f,9.5f,-285f);
            if(hasWon){
                RenderSettings.skybox = otherSkybox;
                DynamicGI.UpdateEnvironment();
            }
        }
        else if(collision.gameObject.CompareTag("Zombie")){
            AudioSource.PlayClipAtPoint(eatingSound, transform.position);
            Destroy(gameObject);
            GameOverScreen.Setup(-3);
        }
        else if(collision.gameObject.CompareTag("Kratos")){
            SpaceDoor3.isCollided = true;
            StopCoroutine(co2);
            collision.gameObject.transform.position = new Vector3(288f, 200f, 255f);
            if(GameObject.FindWithTag("Zeus") != null){
                GameObject.FindWithTag("Zeus").SetActive(false);
            }
            transform.position = new Vector3(300f, 197.3f, 253.1f);
            GameOverScreen.Setup(-4);
        }
        else if(collision.gameObject.CompareTag("Zeus")){
            transform.position = new Vector3(305f, 297.3f, 305f);
            GameOverScreen.Setup(-8);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Grogu")){
            AudioSource.PlayClipAtPoint(groguSound, new Vector3(300f, 197.3f, 295f));
            SpaceDoor.isCollided = true;
            StopCoroutine(co);
            collision.gameObject.transform.position = new Vector3(288f, 198.1f, 294f);
            if(GameObject.FindWithTag("DarthVader") != null){
                GameObject.FindWithTag("DarthVader").SetActive(false);
            }
            transform.position = new Vector3(300f, 197.3f, 295f);
            GameOverScreen.Setup(-5);
        }
        else if(collision.gameObject.CompareTag("DarthVader")){
            transform.position = new Vector3(305f, 297.3f, 305f);
            GameOverScreen.Setup(-9);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("SamuraiJack")){
            SpaceDoor4.isCollided = true;
            StopCoroutine(co3);
            collision.gameObject.transform.position = new Vector3(330f, 199.6f, 294f);
            if(GameObject.FindWithTag("Aku") != null){
                GameObject.FindWithTag("Aku").SetActive(false);
            }
            transform.position = new Vector3(318f, 197.3f, 294f);
            GameOverScreen.Setup(-6);
        }
        else if(collision.gameObject.CompareTag("Aku")){
            transform.position = new Vector3(305f, 297.3f, 305f);
            GameOverScreen.Setup(-10);
            Destroy(gameObject);
        }

        else if(collision.gameObject.CompareTag("Neo")){
            SpaceDoor2.isCollided = true;
            StopCoroutine(co4);
            collision.gameObject.transform.position = new Vector3(330f, 200f, 255f);
            if(GameObject.FindWithTag("AgentSmith") != null){
                GameObject.FindWithTag("AgentSmith").SetActive(false);
            }
            transform.position = new Vector3(318f, 197.3f, 255f);
            GameOverScreen.Setup(-7);
            spacePortal.SetActive(true);
        }
        else if(collision.gameObject.CompareTag("AgentSmith")){
            transform.position = new Vector3(305f, 297.3f, 305f);
            GameOverScreen.Setup(-11);
            Destroy(gameObject);
        }
    }
}
