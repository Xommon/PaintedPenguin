using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string storeId = "3241553";
    private string bannerAd = "bannerAd";
    public bool showBannerAd;

    // Start is called before the first frame update
    void Start()
    {
        // Change to false when publishing
        Advertisement.Initialize(storeId, false);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
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
}
