using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public Health playerHealth;
    public float currentHealth;
    public float maxHealth;
    public TMP_Text healthText;

    private void Start()
    {
        maxHealth = playerHealth.maxHealth;
        healthBar = GetComponent<Image>();  
    }
    // Update is called once per frame
    void Update()
    {
        currentHealth = playerHealth.currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (!gameObject.CompareTag("Enemy")) 
        {
            healthText.text = "HP: " + currentHealth;
        }

        
    }
}
