using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    public static bool GamePaused = false;
    [Tooltip("This is the pause menu that will be visible when the player presses the esc button, or onclicks the pause logo on the right top of the screen, at that time the game pauses")]
    public GameObject pausemenuUI;
    public GameObject settings;
    [Tooltip("This is the instructions canvas that will be visible at the beginning of the game")]
    [SerializeField] GameObject InstructionsUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InstructionsUI.SetActive(true);
        Time.timeScale = 0f;
        pausemenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Debug.Log("i am playing now");
        Time.timeScale = 1f;
        GamePaused = false;

    }
    void Pause()
    {
        pausemenuUI.SetActive(true);
        Debug.Log("i paused now");
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Play(){
        InstructionsUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
    public void volumeChanger(){
        pausemenuUI.SetActive(false);
        settings.SetActive(true);
    }
    public void backToResume(){
        pausemenuUI.SetActive(true);
        settings.SetActive(false);
    }

}
