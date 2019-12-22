using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class Reward : MonoBehaviour
{
    private string storeId = "3241553";
    private string placementId = "rewardedVideo";

    private void Start()
    {
        // Set to false when publishing game
        Monetization.Initialize(storeId, true);
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
            FindObjectOfType<GameManager>().ContinueButton();
        }
    }
}
