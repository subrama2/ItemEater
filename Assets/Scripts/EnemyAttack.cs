using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    //private Transform player;
    private float nextAttackTime = 0.0f;
    
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatground, PlayerDetect;
    //chasing
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    //attacking
    public float timebetweenattack;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    bool playerInSightedRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Player Variant 1").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        // move
        // agent.SetDestination(player.position);
        // agent.destination = PlayerPos.transform.position;
        playerInSightedRange = Physics.CheckSphere(transform.position, sightRange, PlayerDetect);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerDetect);
        //if (player != null && Vector3.Distance(transform.position, player.position) <= attackDistance && Time.time >= nextAttackTime)
        // {
        //nextAttackTime = Time.time + attackRate;
        // Attack();
        //}
        if (playerInSightedRange && !playerInAttackRange) chasePlayer();
        if (playerInSightedRange && playerInAttackRange) AttackPlayer();

    }
    private void chasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked) 
        {
            alreadyAttacked= true;
            Invoke(nameof(resetAttack),timebetweenattack);
        }
       
    }
    private void resetAttack()
    {
        alreadyAttacked= false;
    }
    // Update is called once per frame
    
}
