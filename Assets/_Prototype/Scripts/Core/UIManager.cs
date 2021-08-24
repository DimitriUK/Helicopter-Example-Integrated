using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject ResultsUI;

    public TextMeshProUGUI CompleteText;
    public TextMeshProUGUI LandingText;

    public Button Restart_Button, NextLevel_Button;

    public Image OneStar, TwoStar, ThreeStar;

    public TextMeshProUGUI EngineSpeedText;
    private float EngineSpeedConverted;

    private void Awake()
    {
        instance = this;
        InitUI();
    }

    public void InitUI()
    {
        OneStar.CrossFadeAlpha(0, 0, true); TwoStar.CrossFadeAlpha(0, 0, true); ThreeStar.CrossFadeAlpha(0, 0, true);
    }

    public void ResultsPopup(bool wonLevel, float landingSpeed)
    {
        ResultsUI.SetActive(true);

        if (wonLevel)
        {
            CompleteText.text = "Level Complete!";
            LandingText.gameObject.SetActive(true);
            LandingText.text = "You landed at a speed of: " + landingSpeed;

            NextLevel_Button.interactable = true;
            return;
        }

        else CompleteText.text = "Level Failed!";
    }

    public void StarsPopup(int winId)
    {
        StartCoroutine(StarsPopupTimer(winId));
    }

    public IEnumerator StarsPopupTimer(int winId)
    {
        OneStar.CrossFadeAlpha(1, 0.1f, true);
        yield return new WaitForSeconds(0.2f);

        if (winId == 0)
            yield break;

        yield return new WaitForSeconds(0.2f);

        TwoStar.CrossFadeAlpha(1, 0.1f, true);

        if (winId == 1)
            yield break;

        yield return new WaitForSeconds(0.2f);

        ThreeStar.CrossFadeAlpha(1, 0.1f, true);
    }

    public void RestartButton()
    {
        Application.LoadLevel(Application.loadedLevel); // Notice how this line shows with the squiggly line.
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Notice how this doesn't show the squiggly line.
    }

    public void UpdateSpeedUI(float currentSpeed)
    {
        EngineSpeedConverted = Mathf.RoundToInt(currentSpeed / 40);

        EngineSpeedText.text = "ENGINE POWER: " + EngineSpeedConverted + "%";
    }

}
