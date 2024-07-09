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
    private float movingTime = 4f; // �������� �����̴� �ð�

    private void OnEnable()
    {
        StartCoroutine(LazerSetHide());
    }

    IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(movingTime);

        gameObject.SetActive(false);
    }
}
