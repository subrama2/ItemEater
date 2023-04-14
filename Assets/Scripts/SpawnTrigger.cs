using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public List<GameObject> enemies;
    public Transform originPoint;
    public Vector3 size;
    public int numofEnemies;

    private void Awake()
    {
        originPoint = GetComponent<Transform>();
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
        foreach (Collider collider in Physics.OverlapBox(originPoint.position, size/2))
        {
            if (collider.CompareTag("Player"))
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.SetActive(true);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
