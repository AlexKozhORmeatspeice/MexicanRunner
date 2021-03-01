using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private string playStoreID = "3884021";
    private string appStoreID = "3884020";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;
    private bool usedToday = false;
    private void Start()
    {
        //Advertisement.AddListener(this.gameObject);
        InitializeAdvertisment();
    }

    private void InitializeAdvertisment()
    {
        if (isTargetPlayStore) { Advertisement.Initialize(playStoreID, isTestAd); return; }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        Debug.Log(SceneManager.GetActiveScene().name == "Menu");
        Advertisement.Show(interstitialAd);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlayerPrefs.SetInt("BottlesScore", PlayerPrefs.GetInt("BottlesScore") + 5);
            //usedToday = true;
        }
        if (!Advertisement.IsReady(interstitialAd)) return;

    }

    public void PlayRewardedAd()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlayerPrefs.SetInt("BottlesScore", PlayerPrefs.GetInt("BottlesScore") + 5);
        }
        if (!Advertisement.IsReady(rewardedVideoAd)) return;
        Advertisement.Show(rewardedVideoAd);
    }

    //public void OnUnityAdsReady(string placementId)
    //{
    //    //throw new System.NotImplementedException();
    //}

    //public void OnUnityAdsDidError(string message)
    //{
    //    //throw new System.NotImplementedException();
    //}

    //public void OnUnityAdsDidStart(string placementId)
    //{
    //    //throw new System.NotImplementedException();
    //}

    //public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    //{
    //    switch (showResult)
    //    {
    //        case ShowResult.Failed:

    //            break;

    //        case ShowResult.Finished:
    //            if(placementId == rewardedVideoAd) { Debug.Log("Reward the player"); }
    //            if(placementId == interstitialAd) { Debug.Log("Finished intestitial advertisment"); } 

    //            break;

    //        case ShowResult.Skipped:

    //            break;
    //    }
    //}
}
