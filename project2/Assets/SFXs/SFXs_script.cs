using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXs_script : MonoBehaviour
{
    [Tooltip("The background sound that will keep playing with the game")]
    [SerializeField] AudioSource audio_background;
    // Start is called before the first frame update
    void Start()
    {
        audio_background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)//when game is paused
            audio_background.Stop();
        else    
            audio_background.Play();
    }
}
