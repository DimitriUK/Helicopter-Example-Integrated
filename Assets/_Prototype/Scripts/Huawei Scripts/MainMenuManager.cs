using HmsPlugin;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text consoleText;

    private void Start()
    {
        HMSAccountManager.Instance.SignIn(); // Logs in the Huawei Account when entering the game.
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
    public void OpenAchievements() // If using achievements, you may use this function to open up the native achievements UI.
    {
        HMSAchievementsManager.Instance.ShowAchievements(); // Opens Native Huawei UI for Achievements
    }
    public void OpenLeaderboards() // If using leaderboards, you may use this function to open up the native leaderboards UI.
    {
        HMSLeaderboardManager.Instance.ShowLeaderboards();
    }
    public void ExitGame() // Close the Unity application
    {
        Application.Quit();
    }    
}
