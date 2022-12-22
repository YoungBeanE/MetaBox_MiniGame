using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager_HG : MonoBehaviour
{
    public AudioSource musicsource;
    public AudioSource btnsource;

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }

    public void SetBtnVolume(float volume)
    {
        btnsource.volume = volume;
    }

    public void OnSoundFx()
    {
        btnsource.Play();
    }
}
