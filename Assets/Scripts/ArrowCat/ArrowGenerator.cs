using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    // X 축이 -9 ~ 9 까지
    public GameObject arrowPref;
    private void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        MakeArrow();
        yield return new WaitForSeconds(0.3f);

        StartCoroutine(WaitTime());
    }
    public void MakeArrow()
    {
        GameObject arrowObj = Instantiate(arrowPref);
        arrowObj.transform.position += new Vector3((float)Random.Range(-900, 900)/100, 8);
    }

}
