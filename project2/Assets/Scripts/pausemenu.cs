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

    public delegate void ButtonClicked();
    public static event ButtonClicked Button;  
    ButtonClicked button; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;//make curson visilbe in the canvas
        button += InstructionsMenuVisible;//instructions initially is visible
        button += GameIsPaused;//game is paused
        button += PauseMenuInvisible;//pause menu is invisible
        button();
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
        button += PauseMenuInvisible;//pause menu returns invisible
        Debug.Log("i am playing now");
        button += GameIsResumed;//game is resumed
        GamePaused = false;
        button();
    }
    void Pause()//pause button
    {
        button += PauseMenuVisible;//pause menu is visible
        Debug.Log("i paused now");
        button += GameIsPaused;//game paused
        GamePaused = true;
        button();
    }

    public void Play(){//play button in instructions canvas
        button += InstructionsMenuInvisible;//instructions becomes invisible
        button += GameIsResumed;//game starts
        button();
    }

    public void Quit(){//return to main menu button
        SceneManager.LoadScene(0);
    }

    public void volumeChanger(){//settings button
        button += PauseMenuInvisible;//pause menu disabled
        button += SettingsMenuVisible;//enable settings menu
        button();
    }

    public void backToResume(){//back button ins settings menu
        button += PauseMenuInvisible;
        button += SettingsMenuInvisible;
        button();
    }

    public void PauseMenuInvisible(){
        pausemenuUI.SetActive(false);
    }
    public void PauseMenuVisible(){
        pausemenuUI.SetActive(true);
    }
    public void InstructionsMenuVisible(){
        InstructionsUI.SetActive(true);
    }
    public void InstructionsMenuInvisible(){
        InstructionsUI.SetActive(false);
    }
    public void SettingsMenuInvisible(){
        settings.SetActive(false);
    }
    public void SettingsMenuVisible(){
        settings.SetActive(true);
    }
    public void GameIsPaused(){
        Time.timeScale = 0f;
    }
    public void GameIsResumed(){
        Time.timeScale = 1f;
    }


}
