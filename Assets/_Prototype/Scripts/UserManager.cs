using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
using HuaweiMobileServices.IAP;
using System;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;

    public int PlayerGold;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();

        instance = this;

        PlayerGold = PlayerPrefs.GetInt("Gold", 10);
    }

    private void Start()
    {
        RestoreAds();
    }

    public void AddGold(int goldAmount)
    {
        int calculation = PlayerGold + goldAmount;
        PlayerGold = calculation;

        SaveGold();
    }
    public void RemoveGold(int goldAmount)
    {
        int calculation = PlayerGold - goldAmount;
        PlayerGold = calculation;

        SaveGold();
    }

    private void SaveGold()
    {
        PlayerPrefs.SetInt("Gold", PlayerGold);
    }

    public void RestoreAds()
    {
        HMSIAPManager.Instance.RestorePurchases((returnedList) =>
        {
            foreach (var item in returnedList.ItemList)
            {
                if (item == "no_ads")
                {

                }
            }
        });
    }
}
