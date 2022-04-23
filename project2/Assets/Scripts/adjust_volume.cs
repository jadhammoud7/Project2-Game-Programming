using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class adjust_volume : MonoBehaviour
{
    [SerializeField]
    AudioMixer audio_mixer;
public void setVolume(float volume){
    audio_mixer.SetFloat("volume",volume);
}
}
