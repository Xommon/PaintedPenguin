using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;

public class AdController : MonoBehaviour, IUnityAdsListener
{
    //public static AdController instance;
#if UNITY_IOS
    private string storeId = "3241552" // Apple
#elif UNITY_ANDROID
    private string storeId = "3241553"; // Android
#endif
    private string bannerAd = "bannerAd";
    private string myPlacementId = "rewardedVideo";
    public bool showBannerAd;
    public Text debugText;

    // Debug
    public string rewardResult;
    public string rewardError;
    
    void Start()
    {
        // Change to false when publishing
        Advertisement.Initialize(storeId, true);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.AddListener(this);
    }
    
    private void Update()
    {
        // Close banner whenever the game is running
        if ((showBannerAd == false) || (FindObjectOfType<GameManager>().on == true && FindObjectOfType<GameManager>().paused == false && FindObjectOfType<PlayerMovement>().dead == false))
        {
            CloseBanner();
        }

        // Enable/disable continue button ad icon
        if (Advertisement.IsReady(myPlacementId))
        {
            FindObjectOfType<GameManager>().continueButtonAdIcon.SetActive(true);
        }
        else
        {
            FindObjectOfType<GameManager>().continueButtonAdIcon.SetActive(false);
        }

        // Debug Text
        debugText.text = "Banner: " + Advertisement.IsReady(bannerAd) + "\n" 
            + "Reward: " + Advertisement.IsReady(myPlacementId) + "\n"
            + "ShowBannerAd: " + showBannerAd + "\n"
            + "Reward Result: " + rewardResult + "\n"
            + "Reward Error: " + rewardError;
    }

    public void ShowBanner()
    {
        StartCoroutine(Banner());
        showBannerAd = true;
    }

    public void CloseBanner()
    {
        Advertisement.Banner.Hide();
        showBannerAd = false;
    }

    public bool IsAdReady()
    {
        if (Advertisement.IsReady(bannerAd))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Banner()
    {
        while (IsAdReady() == false)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerAd);
    }

    public void DisplayVideoAd()
    {
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            FindObjectOfType<GameManager>().ContinueButton2();
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            FindObjectOfType<GameManager>().ContinueButton2();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
            //FindObjectOfType<GameManager>().ContinueButton2();
        }

        ///
        rewardResult = showResult.ToString();
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            //Advertisement.Show(myPlacementId);
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
        rewardError = message;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}
