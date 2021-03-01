using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SavesController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bottlesText;
    public TMP_Text nowScore;
    public Character character;
   
    private float startTime;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }
    private void Start()
    {
        //Data.Score = PlayerPrefs.GetInt("DataScore");
        //Data.BottlesCollected = PlayerPrefs.GetInt("BottlesScore");
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        CheckScores();
    }

    private void CheckScores()
    {
        if (!character.Dead)
        {
            if ((int)(Time.time - startTime) > Data.Score)
            {
                Data.Score = (int)(Time.time - startTime);
            }
            scoreText.text = $"Best Score: {Data.Score}";
            nowScore.text = $"Now Score: {(int)(Time.time - startTime)}";
            PlayerPrefs.SetInt("DataScore", Data.Score);
            PlayerPrefs.SetInt("BottlesScore", Data.BottlesCollected);
            bottlesText.text = $"Bottles: {Data.BottlesCollected}";
        }
        else
        {
            startTime = Time.time;
        }

    }
}
