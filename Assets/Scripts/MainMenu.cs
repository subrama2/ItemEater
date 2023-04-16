using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool credits;
    public GameObject creditsWindow;
    public GameObject buttons;
    public void StartGame()
    {
        SceneManager.LoadScene("CaveScene");
    }

    public void Credits()
    {
        if (!credits)
        {
            credits = true;
            creditsWindow.SetActive(true);
            buttons.SetActive(false);
        }
    }

    public void CloseButton()
    {
        credits = false;
        creditsWindow.SetActive(false);
        buttons.SetActive(true);
    }

    public void Retry(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
