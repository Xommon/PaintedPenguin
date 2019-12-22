using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdController : MonoBehaviour
{
    public static AdController instance;

    private string storeId = "3241553";
    private string videoAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "bannerAd";

    // Start is called before the first frame update
    void Start()
    {
        // Change to false when publishing
        Advertisement.Initialize(storeId, true);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void ShowRewarded()
    {
        //StartCoroutine(Rewarded());
    }

    public void ShowBanner()
    {
        StartCoroutine(Banner());
    }

    public void CloseBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator Banner()
    {
        while (!Advertisement.IsReady(bannerAd))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerAd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
