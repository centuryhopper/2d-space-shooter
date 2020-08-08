using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoroutineTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PrintAndWait());
    }

    IEnumerator PrintAndWait()
    {
        Debug.Log("before delay");
        yield return new WaitForSeconds(3f);
        Debug.Log("after delay");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
