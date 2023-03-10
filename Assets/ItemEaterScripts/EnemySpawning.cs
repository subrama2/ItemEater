using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody Prefab;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        Rigidbody RigidPrefab;
        RigidPrefab = Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation) as Rigidbody;
    }

}
