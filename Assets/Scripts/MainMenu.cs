using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool credits;
    public GameObject creditsWindow;
    public GameObject buttons;

    public static int itemsCollected;
    public static int HPCollected;
    public static int SpPCollected;
    public static int StPCollected;

    public void Awake()
    {
        EndGameSummary();
    }

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

    public void EndGameSummary()
    {
        TMP_Text text = GameObject.Find("EndGameText").GetComponent<TMP_Text>();
        if (text != null) { 
        text.text = HPCollected + " Health Potions Collected. \n"
            + StPCollected + " Strength Potions Collected \n"
            + SpPCollected + " Speed Potions Collected \n\n "
            + itemsCollected + " Total Potions Colleced.";
        }
    }
}
