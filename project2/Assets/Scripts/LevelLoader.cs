using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject MainMenuScreen;
    public Slider slider;

    public TextMeshProUGUI progressText;
    public void LoadLevel(int sceneIndex){
       StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex){
         AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);//load a scene synchronously and store the statsus of the current operation into variable operation
         loadingScreen.SetActive(true);
         MainMenuScreen.SetActive(false);
         while(!operation.isDone){
             float progress = Mathf.Clamp01(operation.progress / 0.9f); //clamps the value between 0 and 1
             slider.value = progress;
             progressText.text = progress * 100f + "%";
             yield return new WaitForSeconds(1f);
         }
    }
}
