using HmsPlugin;
using UnityEngine;

public class HuaweiManager : MonoBehaviour
{
    public static HuaweiManager instance;
    public bool IsAdsOn;

    private void Start()
    {
        instance = this;

        CheckIfAdsEnabled();
    }

    public void CheckIfAdsEnabled()
    {
        IsAdsOn = true;

        HMSIAPManager.Instance.RestorePurchases((returnedList) =>
        {
            foreach (var item in returnedList.ItemList)
            {
                if (item == "remove_ads")
                {
                    DisableAds();
                }
            }
        });
    }

    public void DisableAds()
    {
        IsAdsOn = false;
        Debug.Log("ADS HAS BEEN TURNED OFF!");
    }

    public void OpenAd(int adId)
    {
        if (!IsAdsOn)
        {
            Debug.Log("ADS IS OFF, DID NOT PLAY AN AD");
            return;
        }

        switch (adId)
        {
            case 0:
                OpenBannerAd();
                break;
            case 1:
                OpenInterstitialAd();
                break;
            case 2:
                OpenRewardedAd();
                break;
        }
    }

    #region Ad Functions
    private void OpenBannerAd()
    {
        HMSAdsKitManager.Instance.ShowBannerAd();
    }
    private void OpenInterstitialAd()
    {
        HMSAdsKitManager.Instance.ShowInterstitialAd();
    }
    private void OpenRewardedAd()
    {
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }
    #endregion
}
