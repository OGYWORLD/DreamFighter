using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShowParticle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ShowParticle());
    }

    IEnumerator ShowParticle()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
