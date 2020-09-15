using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InitializeAdsScript : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3772418";
#elif UNITY_ANDROID
    private string gameId = "3772419";
#endif
    string myPlacementIdRewardedInShop = "rewardedVideo";
    string myPlacementIdRewardedLvlSuccess = "rewardedVideoLvlSuccess";
    string myPlacementIdBanner = "banner";
    bool testMode = false;

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void ShowRewardedVideo(string myPlacementIdRewarded)
    {
        if (myPlacementIdRewarded == "inShop")
        {
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady(myPlacementIdRewardedInShop))
            {
                Advertisement.Show(myPlacementIdRewardedInShop);
            }
            else
            {
                Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
            }
        }
        else if(myPlacementIdRewarded == "lvlSuccess")
        {
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady(myPlacementIdRewardedLvlSuccess))
            {
                Advertisement.Show(myPlacementIdRewardedLvlSuccess);
            }
            else
            {
                Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
            }
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if(placementId == myPlacementIdRewardedInShop)
            {
                FindObjectOfType<ShopController>().AddCoins(25);
            }
            else if (placementId == myPlacementIdRewardedLvlSuccess)
            {
                FindObjectOfType<GameController>().AddCoin(50);
            }
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementIdRewardedInShop)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(myPlacementIdBanner);
    }
}
