using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public Toggle Effects;
    public Toggle Music;

    private void Start()
    {
        Effects.isOn = PlayerPrefs.GetInt($"EffectsActive") == 0;
        Music.isOn = PlayerPrefs.GetInt($"MusicActive") == 0;

        if (Music.isOn)
        {
            am.SetFloat("musicVolume", 0.0f);
        }
        else { am.SetFloat("musicVolume", -80.0f); }


        if (Effects.isOn)
        {
            am.SetFloat("effectsVolume", 0.0f);
        }
        else
        {
            am.SetFloat("effectsVolume", -80.0f);
        }


    }
    public void AudioVolume(float sliderValue)
    {
        if(!Music.isOn)
        {
            am.SetFloat("musicVolume", -80.0f);
            return;
        }
        am.SetFloat("masterVolume", sliderValue);
    }

    public void MusicOnOff(bool musicActive)
    {
        if(musicActive)
        {
            am.SetFloat("musicVolume", 0.0f);
        } else { am.SetFloat("musicVolume", -80.0f); }
        PlayerPrefs.SetInt($"MusicActive", (musicActive ? 0 : 1));

    }

    public void EffectsOnOff(bool effectsActive)
    {
        if (effectsActive)
        {
            am.SetFloat("effectsVolume", 0.0f);
        }
        else { am.SetFloat("effectsVolume", -80.0f); }
        PlayerPrefs.SetInt($"EffectsActive", (effectsActive ? 0 : 1));
    }
}
