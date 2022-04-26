using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){//when play button is pressed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//enter scene 1
    }

    public void QuitGame(){//when the quit button is pressed
        Debug.Log("Quitted the game!");
        Application.Quit();//quit game
    }
}
