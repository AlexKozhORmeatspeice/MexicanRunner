using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AudioSource buttonSound;

    private void Awake()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void Run()
    {
        SceneManager.LoadScene("Game");
    }

    
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit Pressed");
    }

}
