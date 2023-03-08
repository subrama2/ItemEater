using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Prefab;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
