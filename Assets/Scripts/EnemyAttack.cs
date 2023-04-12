using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
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
    public float attackRange;
    bool playerInSightedRange, playerInAttackRange;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, attackRange);
    }

    void Update()
    {
        // move
        // agent.SetDestination(player.position);
        // agent.destination = PlayerPos.transform.position;
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerDetect);
        //if (player != null && Vector3.Distance(transform.position, player.position) <= attackDistance && Time.time >= nextAttackTime)
        // {
        //nextAttackTime = Time.time + attackRate;
        // Attack();
        //}
        if (playerInAttackRange) AttackPlayer();
        else chasePlayer();

    }
    private void chasePlayer()
    {
        Debug.Log("chase");
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        Debug.Log("attack");
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
