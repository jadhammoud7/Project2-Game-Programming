using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXs_script : MonoBehaviour
{
    AudioSource audio_background;//the audio background that is attached to the player
    // Start is called before the first frame update
    void Start()
    {
        audio_background = GetComponent<AudioSource>();
        audio_background.Play();
    }

    // Update is called once per frame
}
