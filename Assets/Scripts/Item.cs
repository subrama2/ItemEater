using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string type;
    public GameObject player;
    public int amount;
    public MainMenu UI;
    public string displayText = "";

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        UI = GameObject.Find("UI").GetComponent<MainMenu>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            string stat = "";
            switch (type)
            {
                case "health":
                    Health health = player.GetComponent<Health>();
                    health.maxHealth += amount;
                    health.currentHealth = health.maxHealth;
                    stat = "HP";
                    MainMenu.HPCollected++; 
                    break;
                case "strength":
                    PlayerMovement hitbox = player.GetComponent<PlayerMovement>();
                    hitbox.damage += amount;
                    stat = "ST";
                    MainMenu.StPCollected++;
                    break;
                case "speed":
                    PlayerMovement movement = player.GetComponent<PlayerMovement>();
                    movement.speed += amount;
                    stat = "SP";
                    MainMenu.SpPCollected++;
                    break;
                default: break;
            }
            displayText = type + " Potion Collected.  +" + amount + stat;
            MainMenu.itemsCollected++;
            UI.RunPotionText(displayText);
            Destroy(gameObject);
        }
    }
}
