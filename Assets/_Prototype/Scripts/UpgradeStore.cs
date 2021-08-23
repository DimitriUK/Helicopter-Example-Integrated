using UnityEngine;
using TMPro;
using System.Collections;

public class UpgradeStore : MonoBehaviour
{
    [Header("UI General Objects")]
    public TextMeshProUGUI PlayerGold_TEXT;

    [Header("UI Popup Objects")]
    public GameObject PurchaseSuccessful_POPUP;
    public TextMeshProUGUI ProductName_TEXT;
    public TextMeshProUGUI ProductDesc_TEXT;

    void Start()
    {
        PlayerGold_TEXT.text = PlayerPrefs.GetInt("Gold", 10).ToString();
    }

    public void PurchaseUpgrade(int goldPrice)
    {
        if (goldPrice == 50)
        {
            ProductName_TEXT.text = "Takeoff Speed!";
            ProductDesc_TEXT.text = "You can now take off faster!";
        }
        else if (goldPrice == 100)
        {
            ProductName_TEXT.text = "Turning Speed!";
            ProductDesc_TEXT.text = "You can now turn faster!";
        }

        ConfirmGoldDeductionAmount(goldPrice);
    }

    private void ConfirmGoldDeductionAmount(int goldCost)
    {
        int playerGold = UserManager.instance.PlayerGold;
        int calculation = playerGold - goldCost;

        if (calculation < 1)
            return; // Not enough money

        playerGold = playerGold - goldCost;

        PlayerGold_TEXT.text = playerGold.ToString();

        UserManager.instance.RemoveGold(goldCost);

        PurchaseSuccessful_POPUP.SetActive(true);
    }

    public void UpdateGoldUI()
    {
        PlayerGold_TEXT.text = PlayerPrefs.GetInt("Gold", 10).ToString();
    }
}
