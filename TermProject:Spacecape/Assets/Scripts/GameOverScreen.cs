using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public Text spaceText;

    public Text textStatus;

    public Text buttonText;

    public GameObject myButton;

    public GameObject spaceButton;

    public GameObject restartButton;

    public AudioClip newTrack;

    private AudioManager theAM;

    public void Setup(double time) {
        
        gameObject.SetActive(true);

        if(time == 0){

            restartButton.SetActive(true);

            myButton.SetActive(false);

            spaceButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You Drowned!";

        }
        else if(time == -2){

            restartButton.SetActive(true);

            myButton.SetActive(false);

            spaceButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You are Trapped!";

        }
        else if(time == -3){
            
            restartButton.SetActive(true);

            myButton.SetActive(false);

            spaceButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You are Eaten by a Zombie!";
        }
        else if(time == -1){

            restartButton.SetActive(true);

            myButton.SetActive(false);
            spaceButton.SetActive(true);
            textStatus.text = "WRONG CHOICE!";
            pointsText.text = "Think Again!";
            spaceText.text = "Continue!";

        }
        else if(time == -8){
            restartButton.SetActive(true);
            spaceButton.SetActive(false);
            textStatus.text = "WRONG CHOICE!";
            pointsText.text = "Zeus's Lightning Bolt Hit You!";
            myButton.SetActive(false);
        }
        else if(time == -4){
            spaceButton.SetActive(true);
            myButton.SetActive(false);
            textStatus.text = "RIGHT CHOICE!";
            pointsText.text = "That's a God of War 4 Reference!";
            restartButton.SetActive(false);
            spaceText.text = "Solve the Rest!";
        }
        else if(time == -5){
            spaceButton.SetActive(true);
            myButton.SetActive(false);
            textStatus.text = "RIGHT CHOICE!";
            pointsText.text = "It Takes Strength to Resist the Baby Yoda!";
            restartButton.SetActive(false);
            spaceText.text = "Solve the Rest!";
        }
        else if(time == -9){
            restartButton.SetActive(true);
            spaceButton.SetActive(false);
            textStatus.text = "WRONG CHOICE!";
            pointsText.text = "Once You Start Down the Dark Path, Forever Will It Dominate Your Destiny!";
            myButton.SetActive(false);
        }
        else if(time == -6){
            spaceButton.SetActive(true);
            myButton.SetActive(false);
            textStatus.text = "RIGHT CHOICE!";
            pointsText.text = "Evil is Clever and Deception is Its Most Powerful Weapon!";
            restartButton.SetActive(false);
            spaceText.text = "Solve the Rest!";
        }
        else if(time == -10){
            restartButton.SetActive(true);
            spaceButton.SetActive(false);
            textStatus.text = "WRONG CHOICE!";
            pointsText.text = "Do Not Worry, Samurai. You Will See Me Again. But Next Time, You Will Not Be So Fortunate!";
            myButton.SetActive(false);
        }
        else if(time == -7){
            spaceButton.SetActive(true);
            myButton.SetActive(false);
            textStatus.text = "RIGHT CHOICE!";
            pointsText.text = "Let's See How Deep the Rabbit Hole Goes!";
            restartButton.SetActive(false);
            spaceText.text = "Take the Portal!";
        }
        else if(time == -11){
            restartButton.SetActive(true);
            spaceButton.SetActive(false);
            textStatus.text = "WRONG PILL!";
            pointsText.text = "Tell Me, Mr. Anderson...  What Good Is A Phone Call If You're Unable To Speak?";
            myButton.SetActive(false);
        }
        else{
            restartButton.SetActive(true);
            myButton.SetActive(true);
            spaceButton.SetActive(false);
            textStatus.text = "YOU WON!";
            pointsText.text = "You Saved the Watterson Family in " + time.ToString("0.00") + " Seconds!";
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
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach(GameObject zombie in zombies)
        GameObject.Destroy(zombie);
        Destroy(GameObject.FindWithTag("Trap"));
        Destroy(GameObject.FindWithTag("Trap2"));
        Destroy(GameObject.FindWithTag("Trap3"));
        Destroy(GameObject.FindWithTag("Trap4"));
        Destroy(GameObject.FindWithTag("WarningSign"));
        Destroy(GameObject.FindWithTag("WarningSign2"));
        gameObject.SetActive(false);
    }

    public void ContinueButton(){
        gameObject.SetActive(false);
    }

}
