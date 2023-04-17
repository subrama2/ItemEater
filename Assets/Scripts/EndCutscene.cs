using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public Camera cam1;
    public GameObject player;
    public Dialogue dialogueCheck;
    public GameObject dialogueBox;


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
        playerMove.inControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePlayer()
    {
        player.transform.Translate(0, 0, 0.1f);
    }

    IEnumerator EndScene1()
    {
        yield return new WaitForSeconds(1.55f);
        MovePlayer();
        yield return new WaitForSeconds(1.083f);
        dialogueBox.SetActive(true);
    }
}
