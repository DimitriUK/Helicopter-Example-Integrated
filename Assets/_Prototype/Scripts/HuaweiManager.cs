using UnityEngine;

public class HuaweiManager : MonoBehaviour
{
    public static HuaweiManager instance;
    public bool IsAdsOn;

    private void Awake()
    {
        instance = this;

        CheckIfAdsEnabled();
    }

    private void CheckIfAdsEnabled()
    {
        int adsOn = PlayerPrefs.GetInt("Ads", 1);

        if (PlayerPrefs.HasKey("Ads"))
        {
            adsOn = PlayerPrefs.GetInt("Ads");

            if (adsOn == 0)
            {
                IsAdsOn = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Ads", 1);
            IsAdsOn = true;
        }
    }

    public void DisableAds()
    {
        PlayerPrefs.SetInt("Ads", 0);
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
