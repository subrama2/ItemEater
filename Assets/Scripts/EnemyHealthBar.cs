using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    public Health playerHealth;
    public float currentHealth;
    public float maxHealth;

    private Camera _cam;

    private void Start()
    {
        maxHealth = playerHealth.maxHealth;

        _cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        currentHealth = playerHealth.currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;

        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }
}
