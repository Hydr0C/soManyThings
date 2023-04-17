using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroute : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndPrint(1f));

        InvokeRepeating("AIPathFinder", 3f, 1f);
    }

    private void AIPathFinder()
    {
        //check the path validity
        Debug.Log("Validating Path");
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        Debug.Log("First, no time");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Second, times passed: " + waitTime);
        waitTime = waitTime + 4f;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Third, times passed: " + waitTime);
    }
}
