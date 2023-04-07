using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    /**
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject spider in spiders)
            {
                spider.SetActive(true);
            }
        }
    }

    **/
    public GameObject enemyPrefab;
    

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemy();
        }




        void SpawnEnemy()
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 5, Random.Range(-6, 6));
            Instantiate(enemyPrefab, spawnPosition,Quaternion.identity);



        }
    }
}
