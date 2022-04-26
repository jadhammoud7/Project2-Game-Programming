using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    public static bool GamePaused = false;
    [Tooltip("This is the pause menu that will be visible when the player presses the esc button, or onclicks the pause logo on the right top of the screen, at that time the game pauses")]
    public GameObject pausemenuUI;
    [Tooltip("This is the settings menu that will enable the user player to change the volume of the game")]
    public GameObject settings;
    [Tooltip("This is the instructions canvas that will be visible at the beginning of the game")]
    [SerializeField] GameObject InstructionsUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;//make curson visilbe in the canvas
        InstructionsUI.SetActive(true);//instructions initially is visible
        Time.timeScale = 0f;//game is paused
        pausemenuUI.SetActive(false);//pause menu is invisible
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//when pressing ESC button
        {
            if (GamePaused)//if game is paused the resume
            {
                Resume();
            }
            else//if game is not paused then pause
            {
                Pause();
            }
        }
        if (GamePaused)//if game is paused and presses Q
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0);//return to main menu which is scene number 0
            }
        }
    }
    public void Resume()//resume button
    {
        pausemenuUI.SetActive(false);//pause menu returns invisible
        Debug.Log("i am playing now");
        Time.timeScale = 1f;//game is resumed
        GamePaused = false;

    }
    void Pause()//pause button
    {
        pausemenuUI.SetActive(true);//pause menu is visible
        Debug.Log("i paused now");
        Time.timeScale = 0f;//game paused
        GamePaused = true;
    }

    public void Play(){//play button in instructions canvas
        InstructionsUI.SetActive(false);//instructions becomes invisible
        Time.timeScale = 1f;//game starts
    }

    public void Quit(){//return to main menu button
        SceneManager.LoadScene(0);
    }

    public void volumeChanger(){//settings button
        pausemenuUI.SetActive(false);//pause menu disabled
        settings.SetActive(true);//enable settings menu
    }

    public void backToResume(){//back button ins settings menu
        pausemenuUI.SetActive(true);
        settings.SetActive(false);
    }


}
