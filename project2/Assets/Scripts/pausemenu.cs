using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    
    public  static bool GamePaused=false;
    public GameObject pausemenuUI;

    // Update is called once per frame
 void Start() {
    pausemenuUI.SetActive(false);
}

     public void QuitGamebtn(){
        Debug.Log("quited");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused){
                Resume();
            }else{
                Pause();
            }
        } 
        if(GamePaused){
        if(Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(0);
        }
        }
    }
    public void Resume(){
        pausemenuUI.SetActive(false);
        Debug.Log("i am playing now");
        Time.timeScale=1f;
        GamePaused=false;

    }
    void Pause(){
        pausemenuUI.SetActive(true);
        Debug.Log("i paused now");
        Time.timeScale=0f;
        GamePaused=true;
    }


}   
