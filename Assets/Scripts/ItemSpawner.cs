using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int[] numOfEnemies;
    public GameObject ItemPrefab;
    public Transform originPoint;
    public Vector3 size;

    private void Start()
    {
        Debug.Log(GameObject.FindWithTag("Enemy"));
    }

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
        foreach (Collider collider in Physics.OverlapBox(originPoint.position, size / 2))
        {
            if (collider.CompareTag("Player"))
            {
                
                for (int i = 0; i <= 2; i++)
                {
                    SpawnItem();
                }
                Destroy(gameObject);
            }
        }
    }

    void SpawnItem()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        Instantiate(ItemPrefab, gameObject.transform.position + spawnPosition, Quaternion.identity);
    }


}
