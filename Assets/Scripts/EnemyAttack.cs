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
    public Animator anim;
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
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
        agent.SetDestination(player.position);
        anim.SetBool("attack", false);
    }
    private void AttackPlayer()
    {
        if (gameObject.tag == "Dragon")
        {
            float num = Random.Range(0f, 1f);
            if (num > 0.8f)
            {
                anim.SetBool("hornAttack", true);
            } else
            {
                anim.SetBool("hornAttack", false);
            }
        }
        agent.SetDestination(transform.position);
        anim.SetBool("attack", true);
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
