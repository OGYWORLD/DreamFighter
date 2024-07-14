using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class WorldTitleObject : MonoBehaviour
{
    readonly Vector3 initPos = new Vector3(52.07f, -12.37f, 27.77f);
    readonly Quaternion initRotation = Quaternion.Euler(new Vector3(-5.977f, 239.822f, 0.123f));

    private void Start()
    {
        StartCoroutine(FlyInTitleCoroutine());
    }

    private void OnDisable()
    {
        StartCoroutine(FlyOutTitleCoroutine());
    }

    IEnumerator FlyInTitleCoroutine()
    {
        yield return null;

        //StartCoroutine(FloatTitleCoroutine());
    }

    IEnumerator FlyOutTitleCoroutine()
    {
        yield return null;

        //StopAllCoroutines();
    }

    IEnumerator FloatTitleCoroutine()
    {
        Vector3 initPos = transform.position;

        while (true)
        {



            yield return new WaitForSeconds(1f);
        }


    }
}
