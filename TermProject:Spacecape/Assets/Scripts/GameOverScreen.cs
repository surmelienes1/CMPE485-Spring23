using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public Text textStatus;

    public Text buttonText;

    public GameObject myButton;

    public AudioClip newTrack;

    private AudioManager theAM;

    public void Setup(double time) {
        
        gameObject.SetActive(true);

        if(time == 0){

            myButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You Drowned!";

        }
        else if(time == -2){

            myButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You are Trapped!";

        }
        else if(time == -3){

            myButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You are Eaten by a Zombie!";
        }
        else if(time == -1){

            textStatus.text = "WRONG CHOICE!";
            pointsText.text = "Think Again!";
            buttonText.text = "Continue!";

        }
        else{

            textStatus.text = "YOU WON!";

            pointsText.text = time.ToString("0.00") + " Seconds";

        }

    }

    void Start()
    {

        theAM = FindObjectOfType<AudioManager>();
        
    }

    public void RestartButton(){
        Debug.Log("Switching music");
        if(newTrack != null)
        {
            theAM.ChangeBGM(newTrack);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton(){
        if(newTrack != null)
        {
            theAM.ChangeBGM(newTrack);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExploreButton(){
        if(newTrack != null)
        {
            theAM.ChangeBGM(newTrack);
        }
        Destroy(GameObject.FindWithTag("Trap"));
        Destroy(GameObject.FindWithTag("Trap2"));
        Destroy(GameObject.FindWithTag("Trap3"));
        Destroy(GameObject.FindWithTag("Trap4"));
        Destroy(GameObject.FindWithTag("WarningSign"));
        Destroy(GameObject.FindWithTag("WarningSign2"));
        gameObject.SetActive(false);
    }

}
