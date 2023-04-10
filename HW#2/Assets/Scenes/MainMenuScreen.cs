using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{

    public void StartButton(){
        SceneManager.LoadScene("DemoScene");
    }

    public void ExitButton(){
        Application.Quit();
    }

}
