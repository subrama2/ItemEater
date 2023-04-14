using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth, maxHealth;

    public GameObject itemPrefab;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    public bool isDead = false;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    } 
    
    public void GetHit(int amount, GameObject sender)
    {
        if (isDead) return;
        if (sender.layer == gameObject.layer) return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        } else
        {
            OnDeathWithReference?.Invoke(sender);
            if (gameObject.tag == "Enemy")
            {
                SpawnItem();
            }
                isDead = true;
            //Destroy(gameObject);
        }
    }

    void SpawnItem()
    {
        if (itemPrefab == null)
        {
            return;
        }
        Instantiate(itemPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
