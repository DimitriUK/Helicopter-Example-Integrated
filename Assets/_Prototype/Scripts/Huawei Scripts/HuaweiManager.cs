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

    public void CheckIfAdsEnabled() // This function will run a check through all the Huawei user's purchases for this game and check if an item exists of the name 'ads_remove'
    {
        IsAdsOn = true;

        HMSIAPManager.Instance.RestorePurchases((returnedList) =>
        {
            foreach (var item in returnedList.ItemList)
            {
                if (item == "ads_remove")
                {
                    DisableAds(); // If item was found with the name 'ads_remove' - Run the function DisableAds();
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
            Debug.Log("Ads Test: ADS IS OFF, DID NOT PLAY AN AD");
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
        HMSAdsKitManager.Instance.ShowBannerAd(); // Plays banner-based Huawei Ad
    }
    private void OpenInterstitialAd()
    {
        HMSAdsKitManager.Instance.ShowInterstitialAd(); // Plays interstitial-based Huawei Ad
    }
    private void OpenRewardedAd()
    {
        HMSAdsKitManager.Instance.ShowRewardedAd(); // Plays rewarded-based Huawei Ad
    }
    #endregion
}
