using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("This is the settings menu that will enable the user player to change the volume of the game")]
    public GameObject settings;

    public GameObject MainMenuUI;

    public delegate void EventAction();
    public static event EventAction action;
    public void PlayGame(){//when play button is pressed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//enter scene 1
    }

    public void QuitGame(){//when the quit button is pressed
        Debug.Log("Quitted the game!");
        Application.Quit();//quit game
    }
    public void volumeChanger(){//settings button
       MainMenuUI.SetActive(false);
       settings.SetActive(true);
    }
    public void returnToMainMenu(){
        settings.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
