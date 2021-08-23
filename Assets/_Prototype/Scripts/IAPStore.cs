using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HmsPlugin;
using HuaweiMobileServices.IAP;

public class IAPStore : MonoBehaviour
{
    [Header("UI General Objects")]
    public TextMeshProUGUI PlayerGold_TEXT;

    [Header("UI Popup Objects")]
    public GameObject PurchaseSuccessful_POPUP;
    public TextMeshProUGUI ProductName_TEXT;
    public Image ProductImage_IMG;
    public TextMeshProUGUI ProductDesc_TEXT;

    private void Start()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;

        PlayerGold_TEXT.text = PlayerPrefs.GetInt("Gold", 10).ToString();
    }    

    public void BuyIAPProduct(string productId)
    {
        HMSIAPManager.Instance.BuyProduct(productId);
    }

    private void OnBuyProductSuccess(PurchaseResultInfo obj)
    {
        string productId = obj.InAppPurchaseData.ProductId;

        if (productId.Equals(HMSIAPConstants.remove_ads))
        {
            PlayerPrefs.SetInt("Ads", 0);
        }
        else if (productId.Equals(HMSIAPConstants.obtain_gold_100))
        {
            BuyCoins(100);
        }
        else if (productId.Equals(HMSIAPConstants.obtain_gold_200))
        {
            BuyCoins(200);
        }
    }

    private void BuyCoins(int goldAmount)
    {
        if (goldAmount == 100)
        {
            ProductName_TEXT.text = "100 Gold";
            ProductImage_IMG.sprite = SpriteLibrary.instance.Coins100;
            ProductDesc_TEXT.text = "You bought 100 Gold coins!";
        }
        else if (goldAmount == 200)
        {
            ProductName_TEXT.text = "200 Gold";
            ProductImage_IMG.sprite = SpriteLibrary.instance.Coins200;
            ProductDesc_TEXT.text = "You bought 200 Gold coins!";
        }

        ActivatePurchaseSuccessfulPopup();

        int playerGold = UserManager.instance.PlayerGold;
        int calculation = playerGold + goldAmount;

        PlayerGold_TEXT.text = calculation.ToString();
        UserManager.instance.AddGold(goldAmount);      
    }

    private void ActivatePurchaseSuccessfulPopup()
    {
        PurchaseSuccessful_POPUP.SetActive(true);
    }
    public void UpdateGoldUI()
    {
        PlayerGold_TEXT.text = PlayerPrefs.GetInt("Gold", 10).ToString();
    }
}
