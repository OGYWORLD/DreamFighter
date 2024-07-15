using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResultPrint : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetHide());
    }

    IEnumerator SetHide()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
