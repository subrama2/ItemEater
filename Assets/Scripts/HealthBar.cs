using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public Health playerHealth;
    public float currentHealth;
    public float maxHealth;

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
    }
}
