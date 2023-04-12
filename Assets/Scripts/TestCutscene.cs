using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCutscene : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2.0f);
        cam1.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        cam2.SetActive(false);
        cam3.SetActive(true);
    }
}
