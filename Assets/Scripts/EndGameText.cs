using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameText : MonoBehaviour
{
    
    void Awake()
    {
        EndGameSummary();
    }

    public void EndGameSummary()
    {
        TMP_Text text = GameObject.Find("EndGameText").GetComponent<TMP_Text>();
        if (text != null)
        {
            text.text = MainMenu.HPCollected + " Health Potions Collected. \n"
                + MainMenu.StPCollected + " Strength Potions Collected \n"
                + MainMenu.SpPCollected + " Speed Potions Collected \n\n "
                + MainMenu.itemsCollected + " Total Potions Colleced.";
        }
    }
}
