using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// ��Ȯ�� ��Ʈ �Է� ��, Ȱ��ȭ�Ǵ� ��ƼŬ�� ������ ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CShowParicle : MonoBehaviour
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
