using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0;i <= 2; i++ )
            {
                SpawnEnemy();
            }
            Destroy(gameObject);
        }




        void SpawnEnemy()
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
            Instantiate(enemyPrefab, gameObject.transform.position + spawnPosition, Quaternion.identity);
        }
    }
}
