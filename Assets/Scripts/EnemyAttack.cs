using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackDistance = 2.0f;
    public float attackRate = 1.0f;
    public int attackDamage = 10;
    private Transform player;
    private float nextAttackTime = 0.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackDistance && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackRate;
// Attack();
        }
    }
}
