using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelLoader : MonoBehaviour
{
    [Tooltip("The loading screen canvas that displays a centered loading bar before starting the game, and after clicking play in the main menu")]
    public GameObject loadingScreen;
    [Tooltip("The main menu which is the starter page of the game")]
    public GameObject MainMenuScreen;
    [Tooltip("slider of the loading bar that will increase from 0 to 100")]
    public Slider slider;
    [Tooltip("The text displaying the progress of the loading in %")]
    public TextMeshProUGUI progressText;
    
    public void LoadLevel(int sceneIndex){
       StartCoroutine(LoadAsynchronously(sceneIndex));//start the coroutine
    }

    IEnumerator LoadAsynchronously(int sceneIndex){
         AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);//load a scene synchronously and store the statsus of the current operation into variable operation
         loadingScreen.SetActive(true);//load screen becomes active
         MainMenuScreen.SetActive(false);//disable main menu page
         while(!operation.isDone){//whenever the loading is not completed
             float progress = Mathf.Clamp01(operation.progress / 0.9f); //clamps the value between 0 and 1
             slider.value = progress;//slider values becomes progress
             progressText.text = progress * 100f + "%";//display the progress text in % 
             yield return new WaitForSeconds(1f);
         }
    }
}
