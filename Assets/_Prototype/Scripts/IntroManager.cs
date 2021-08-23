using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public CanvasGroup cg;

    bool isActive;

    void Start()
    {
        isActive = true;

        StartCoroutine(MainMenuTimer());
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            cg.alpha += 0.01f;
        }
    }

    private IEnumerator MainMenuTimer()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
    }
}
