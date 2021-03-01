using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseS : MonoBehaviour
{
    private bool active = false;
    public AudioMixer am;
    // Start is called before the first frame update
    public void StopOrActiveGame()
    {
        if(!active) { am.SetFloat("masterVolume", -80.0f); Time.timeScale = 0; active = true; }
        else { am.SetFloat("masterVolume", 0.0f); Time.timeScale = 1; active = false; }
    }
}
