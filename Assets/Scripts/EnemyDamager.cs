using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public Transform originPoint;
    public float radius;
    public float knockbackStrength;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            DetectColliders();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = originPoint == null ? Vector3.zero : originPoint.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {
        foreach (Collider collider in Physics.OverlapSphere(originPoint.position, radius))
        {
            Vector3 direction = collider.transform.position - transform.position;
            direction.y = 0;
            //Debug.Log(collider.name);
            Rigidbody rb;
            Health health;
            if ((health = collider.GetComponent<Health>()) && collider.tag == "Player")
            { 
                health.GetHit(damage, transform.parent.gameObject);
                rb = collider.GetComponent<Rigidbody>();
                rb.AddForce(direction.normalized * knockbackStrength * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
