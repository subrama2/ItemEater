using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject playerCam;
    public PlayerMovement playerControl;
    public Dialogue dialogueCheck;
    public GameObject dialogueBox;

    void Start()
    {
        playerControl.inControl = false;
        StartCoroutine(Intro());
    }

    private void Update()
    {
        if (dialogueCheck.textDone)
        {
            StartCoroutine(IntroEnd());
        }
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(7.0f);
        dialogueBox.SetActive(true);
    }

    IEnumerator IntroEnd()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2.10f);
        cam2.SetActive(false);
        playerCam.SetActive(true);
        playerControl.inControl = true;
        gameObject.SetActive(false);
    }
}
