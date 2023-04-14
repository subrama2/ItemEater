using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string type;
    public GameObject player;
    public int amount;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case "health":
                    Health health = player.GetComponent<Health>();
                    health.maxHealth += amount;
                    health.currentHealth = health.maxHealth;
                    break;
                case "strength":
                    PlayerMovement hitbox = player.GetComponent<PlayerMovement>();
                    hitbox.damage += amount;
                    break;
                case "speed":
                    PlayerMovement movement = player.GetComponent<PlayerMovement>();
                    movement.speed += amount;
                    break;
                default: break;
            }
            Destroy(gameObject);
        }
    }
}
