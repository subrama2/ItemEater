using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public List<GameObject> enemies;
    public Transform originPoint;
    public Vector3 size;
    private int enemyCount = 0;

    private void Start()
    {
        for (int i = 0; i <= enemies.Count - 1; i++)
        {
            enemyCount++;
        }
        Debug.Log(enemyCount);
    }

    private void Update()
    {
        CheckEnemies();
        if (enemyCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 position = originPoint == null ? Vector3.zero : originPoint.position;
        Gizmos.DrawWireCube(position, size);
    }

    void CheckEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.IsDestroyed())
            {
                enemyCount--;
                enemies.Remove(enemy);
                Debug.Log(enemyCount);

            }
        }
    }


}
