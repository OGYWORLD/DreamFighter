using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// ������ Ȱ��ȭ �� �̵� �ð� ���� ��Ȱ��ȭ �ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CLazerSetActive : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(LazerSetHide());
    }

    IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(StageManager.instance.noteMoveSpeed);

        gameObject.SetActive(false);
    }
}
