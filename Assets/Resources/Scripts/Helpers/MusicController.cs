using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource RUNTHEME;
    [SerializeField]
    private AudioSource deathSound;
    private Character character;
    private bool playedDeathSound;

    private void Awake()
    {
        RUNTHEME = GetComponent<AudioSource>();
        character = FindObjectOfType<Character>();
        playedDeathSound = false;
    }

    private void Update()
    {
        if(!character.Dead)
        {
            if(!RUNTHEME.isPlaying)
            {
                RUNTHEME.Play();
            }
        } else
        {
            if(!playedDeathSound)
            {
                RUNTHEME.Stop();
                deathSound.Play();
                playedDeathSound = true;
            }
        }
    }

}
