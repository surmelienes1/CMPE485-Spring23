using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public Text textStatus;

    public GameObject myButton;

    public void Setup(double time) {
        
        gameObject.SetActive(true);

        if(time == 0){

            myButton.SetActive(false);

            textStatus.text = "GAME OVER";
    
            pointsText.text = "You Died!";

        }

        else{

            textStatus.text = "YOU WON!";

            pointsText.text = time.ToString("0.00") + " Seconds";

        }

    }

    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExploreButton(){
        Destroy(GameObject.FindWithTag("Trap"));
        Destroy(GameObject.FindWithTag("Trap2"));
        Destroy(GameObject.FindWithTag("Trap3"));
        Destroy(GameObject.FindWithTag("Trap4"));
        Destroy(GameObject.FindWithTag("WarningSign"));
        Destroy(GameObject.FindWithTag("WarningSign2"));
        gameObject.SetActive(false);
    }

}
