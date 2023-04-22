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
    public GameObject hitbox;
    public AudioSource dragonRoar;
    //chasing
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    //attacking
    public float timebetweenattack;
    public float windUpTime; // time it takes for attack to wind up
    public float attackingPeriod; // the period of time the hitbox is active.
    bool alreadyAttacked;

    //states
    public float attackRange;
    bool playerInSightedRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (gameObject.name == "DragonBoss")
        {
            dragonRoar.Play();
        }
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
        Debug.Log(alreadyAttacked);
    }
    private void chasePlayer()
    {
        agent.SetDestination(player.position);
        anim.SetBool("attack", false);
    }
    private void AttackPlayer()
    {
        /*if (gameObject.tag == "Dragon")
        {
            float num = Random.Range(0f, 1f);
            if (num > 0.8f)
            {
                anim.SetBool("hornAttack", true);
            } else
            {
                anim.SetBool("hornAttack", false);
            }
        }*/
        agent.SetDestination(transform.position);
        anim.SetBool("attack", true);       
        if(!alreadyAttacked) 
        {
            alreadyAttacked = true;
            StartCoroutine(Attacking());
            Invoke(nameof(resetAttack),timebetweenattack);
        }
       
    }
    private void resetAttack()
    {
        Debug.Log("resetAttack");
        alreadyAttacked= false;
        hitbox.SetActive(false);
    }
    // Update is called once per frame

    IEnumerator Attacking()
    {
        Debug.Log("Wind Up");
        yield return new WaitForSeconds(windUpTime);
        hitbox.SetActive(true);
        Debug.Log("Attack");
        yield return new WaitForSeconds(attackingPeriod);
        Debug.Log("End Attack");
        hitbox.SetActive(false);
        yield return new WaitForSeconds(timebetweenattack - windUpTime - attackingPeriod);
        
    }
}
