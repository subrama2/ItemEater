using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    public Transform EnemyPos;
    private float RepeatCycle = 4f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0.5f, RepeatCycle);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void EnemySpawner()
    {
        Instantiate(Enemy, EnemyPos.position, EnemyPos.rotation);
    }
}
