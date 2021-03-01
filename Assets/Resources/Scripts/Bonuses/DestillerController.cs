using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DestillerController : MonoBehaviour
{
    private AudioSource buyingSound;
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text upgradeText;

    [SerializeField]
    private int startMaxBottles;

    private int nowMaxBottles;
    private Slider slider;

    [SerializeField]
    private int startCostOfUpgrade;

    private int costOfUpgrade;

    [SerializeField]
    private int plusToEveryUpgradeOfCostUpgrade;
    [SerializeField]
    private int plusToEveryUpgradeOfMaxBottles;

    // Start is called before the first frame update
    void Awake()
    {
        nowMaxBottles = startMaxBottles + plusToEveryUpgradeOfCostUpgrade * PlayerPrefs.GetInt("DistLevel");
        Data.maxBottles = nowMaxBottles;
        costOfUpgrade = startCostOfUpgrade + plusToEveryUpgradeOfCostUpgrade * PlayerPrefs.GetInt("DistLevel");
        Data.BottlesCollected = PlayerPrefs.GetInt("BottlesScore");

        scoreText = GetComponentInChildren<TMP_Text>();
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = nowMaxBottles;

        buyingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    
    void Update()
    {
        nowMaxBottles = startMaxBottles + plusToEveryUpgradeOfCostUpgrade * PlayerPrefs.GetInt("DistLevel");
        costOfUpgrade = startCostOfUpgrade + plusToEveryUpgradeOfCostUpgrade * PlayerPrefs.GetInt("DistLevel");
        Data.BottlesCollected = PlayerPrefs.GetInt("BottlesScore");

        slider.value = Data.BottlesCollected;
        scoreText.text = $"{Data.BottlesCollected} / {nowMaxBottles}";
        upgradeText.text = $"Upgrade:\n {costOfUpgrade}";
    }

    public void UpgradeDist()
    {
        if(Data.BottlesCollected >= costOfUpgrade)
        {
            buyingSound.Play();
            PlayerPrefs.SetInt("DataScore", PlayerPrefs.GetInt("DataScore") - costOfUpgrade);

            PlayerPrefs.SetInt("DistLevel", PlayerPrefs.GetInt("DistLevel") + 1);

            Debug.Log($"Now level of Dist is {PlayerPrefs.GetInt("DistLevel")}");
        }
    }
}
