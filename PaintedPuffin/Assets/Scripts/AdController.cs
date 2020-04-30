using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string storeId = "3241553"; // Android
    //private string storeId = "3241552"; // Apple
    private string bannerAd = "bannerAd";
    public bool showBannerAd;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == false)
        {
            // Change to false when publishing
            Advertisement.Initialize(storeId, false);
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }
    }

    public void ShowBanner()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == false)
        {
            StartCoroutine(Banner());
            showBannerAd = true;
        }
    }

    public void CloseBanner()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == false)
        {
            Advertisement.Banner.Hide();
            showBannerAd = false;
        }
    }

    public bool IsAdReady()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == false)
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
        else
        {
            return false;
        }
    }

    IEnumerator Banner()
    {
        if (FindObjectOfType<GameManager>().googleAdsEnabled == false)
        {
            while (IsAdReady() == false)
            {
                yield return new WaitForSeconds(0.5f);
            }
            Advertisement.Banner.Show(bannerAd);
        }
    }
}
