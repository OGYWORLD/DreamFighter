using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class WorldTitleObject : MonoBehaviour
{
    readonly Vector3 initPos = new Vector3(52.07f, -12.37f, 27.77f);
    readonly Quaternion initRotation = Quaternion.Euler(new Vector3(-5.977f, 239.822f, 0.123f));

    Animator animator;

    //===============================================================================================

    private void Awake()
    {
        animator = GetComponent<Animator>();

        transform.position = initPos;
        transform.rotation = initRotation;
    }

    private void Start()
    {
        StartCoroutine(FlyInTitleCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //================================================================================================

    IEnumerator FlyInTitleCoroutine()
    {
        yield return null;

        StartCoroutine(FloatTitleCoroutine());
    }

    public void FlyOutTitle()
    {
        StartCoroutine(FlyOutTitleCoroutine());
    }

    IEnumerator FlyOutTitleCoroutine()
    {
        animator.SetTrigger("Fly Out");
        yield return null;
    }

    IEnumerator FloatTitleCoroutine()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isFloating", true);
    }
}