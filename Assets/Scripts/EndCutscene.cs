using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject player;
    public Dialogue dialogueCheck;
    public GameObject dialogueBox;
    public GameObject endText;
    private bool isPlayerMoving;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
        playerMove.inControl = false;

        StartCoroutine(EndScene1());
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerMoving)
        {
            MovePlayer();
        }

        if (dialogueCheck.textDone)
        {
            StartCoroutine(EndScene2());
        }
    }

    void MovePlayer()
    {
        player.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    IEnumerator EndScene1()
    {
        yield return new WaitForSeconds(1.55f);
        isPlayerMoving = true;
        yield return new WaitForSeconds(1.083f);
        dialogueBox.SetActive(true);
        isPlayerMoving = false;
    }

    IEnumerator EndScene2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(1.67f);
        endText.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
