using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �������� �Բ� ��µǴ� ��� �̹����� Ȱ��ȭ ��Ű�� ��ũ��Ʈ �Դϴ�.
/// </summary>

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
