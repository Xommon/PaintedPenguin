using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class Reward2 : MonoBehaviour
{
    private string storeId = "3241553"; // Android
    //private string storeId = "3241552"; // Apple
    private string placementId = "rewardedVideo";

    private void Start()
    {
        // Set to false when publishing game
        Monetization.Initialize(storeId, false);
    }

    public void ShowId()
    {
        StartCoroutine(WaitForAd());
    }

    IEnumerator WaitForAd()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show(AdFinished);
        }
    }

    void AdFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            FindObjectOfType<GameManager>().ContinueButton2();
        }
    }
}
