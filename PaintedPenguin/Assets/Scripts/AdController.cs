using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    public string store_id = "3241553";

    public string video_ad = "video";
    public string rewarded_video_ad = "rewardedVideo";
    public string banner_ad = "bannerAd";

    // WHEN YOU PUBLISH GAME, CHANGE TO FALSE
    public bool testing = true;

    // Start is called before the first frame update
    void Start()
    {
        // WHEN YOU PUBLISH GAME, CHANGE TO FALSE
        Monetization.Initialize(store_id, true);
    }

    public void OpenVideoAd()
    {
        if (Monetization.IsReady(video_ad) && testing == false)
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void OpenRewardedVideoAd()
    {
        if (Monetization.IsReady(rewarded_video_ad) && testing == false)
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void OpenBannerAd()
    {
        if (Monetization.IsReady(banner_ad) && testing == false)
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void CloseAd()
    {
        ShowAdPlacementContent ad = null;
    }
}
