using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �������� ������ Ÿ�̹� ǥ�ÿ� �� �������� Ȱ��ȭ ��Ű�� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CCircleControl : MonoBehaviour
{
    public Transform circle; // �� ������

    private float appearTime = 4f; // �� �������� �پ��� �ð�
    public Vector3 targetSize; // �پ����� ���� ������
    public Vector3 initialSize; // ���� �ʱ� ������

    private void OnEnable()
    {
        StartCoroutine(CircleSet());
    }

    IEnumerator CircleSet()
    {
        float sumTime = 0f;

        while (sumTime <= appearTime)
        {
            float t = sumTime / appearTime;
            circle.localScale = Vector3.Lerp(initialSize, targetSize, t);

            sumTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
