using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void DeleteAllSavedDataAndRestartGame()
    {
        PlayerPrefs.DeleteAll();
        RestartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
