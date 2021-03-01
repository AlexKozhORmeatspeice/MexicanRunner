using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class DeathScreneS : MonoBehaviour
{
    // Start is called before the first frame update
    //private bool active = false;
    public GameObject menu;
    Character character;

    private int intNumOfTask = 0;


    private void Start()
    {
        character = FindObjectOfType<Character>();
    }
    private void Update()
    {
        if(character.Dead && !menu.activeSelf)
        {
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void LoadMenu()
    {
        Data.characterAtacked = false;
        Time.timeScale = 1.0f;
        menu.SetActive(false);
        character.Dead = false;
        SceneManager.LoadScene("Menu");
    }

    //public void CheckAnswer()
    //{
    //    Debug.Log($"{field.text.ToUpper()} and {trueAnswer.ToUpper()}");
    //    if (field.text.ToUpper() == trueAnswer.ToUpper())
    //    {
    //        Time.timeScale = 1.0f;
    //        menu.SetActive(false);
    //        character.Lives = 1;
    //        character.Dead = false;
    //        //Data.characterAtacked = false;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1.0f;
    //        Data.characterAtacked = false;
    //        SceneManager.LoadScene("Menu");
    //    }
    //}


}
