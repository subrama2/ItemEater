using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject enemyPrefab;
    public GameObject itemSpawner;
    public Transform originPoint;
    public Vector3 size;
    public int numofEnemies;
    private int enemiesAlive = 0;

    private void Awake()
    {
        originPoint = GetComponent<Transform>();
        for (int i = 0; i <= enemies.Count - 1; i++)
        {
            SpawnEnemy(i);
            enemiesAlive++;
            Debug.Log(enemiesAlive);
        }
    }

    private void Update()
    {
        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = originPoint == null ? Vector3.zero : originPoint.position;
        Gizmos.DrawWireCube(position, size);
    }

    public void DetectColliders()
    {
        foreach (Collider collider in Physics.OverlapBox(originPoint.position, size / 2))
        {
            if (collider.CompareTag("Enemy"))
            {
                
            }
        }
    }

    void SpawnEnemy(int index)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        Instantiate(enemies[index], gameObject.transform.position + spawnPosition, Quaternion.identity);
    }
}
