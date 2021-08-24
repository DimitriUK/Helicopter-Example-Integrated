using UnityEngine;

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
}
