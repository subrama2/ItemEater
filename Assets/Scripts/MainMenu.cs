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
    public TMP_Text potionText;
    public AudioSource potionCollectSound;

    public static int itemsCollected;
    public static int HPCollected;
    public static int SpPCollected;
    public static int StPCollected;

    public void Awake()
    {
        Time.timeScale = 1;
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

    public void RunPotionText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(PotionNotify(text));
    }

    IEnumerator PotionNotify(string text)
    {
        potionCollectSound.Play();
        potionText.text = text;
        yield return new WaitForSeconds(2);
        potionText.text = "";
    }
}
