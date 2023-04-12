using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform originPoint;
    public Vector3 size;
    public int numofEnemies;

    private void Update()
    {
        DetectColliders();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 position = originPoint == null ? Vector3.zero : originPoint.position;
        Gizmos.DrawWireCube(position, size);
    }

    public void DetectColliders()
    {
        foreach (Collider collider in Physics.OverlapBox(originPoint.position, size/2))
        {
            if (collider.CompareTag("Player"))
            {
                for (int i = 0; i <= numofEnemies; i++)
                {
                    SpawnEnemy();
                }
                Destroy(gameObject);
            }
        }
    }

    void SpawnEnemy()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        Instantiate(enemyPrefab, gameObject.transform.position + spawnPosition, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i <= 2; i++)
            {
                SpawnEnemy();
            }
            Destroy(gameObject);
        }
    }
}
