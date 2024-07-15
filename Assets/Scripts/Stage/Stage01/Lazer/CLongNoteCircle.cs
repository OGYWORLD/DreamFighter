using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �� ��Ʈ�� ����� ���� Ÿ�̹��� ��Ÿ���� ���� �������� ���۽�Ű�� ��ũ��Ʈ �Դϴ�.
/// </summary>

public class CLongNoteCircle : MonoBehaviour
{
    public Transform circle; // �� ������

    public Vector3 targetSize; // �پ����� ���� ������
    public Vector3 initialSize; // ���� �ʱ� ������

    public CLazerSetActive lazerSet;

    private void OnEnable()
    {
        StartCoroutine(CircleSet());
    }

    IEnumerator CircleSet()
    {
        // OnEnable�� Start �Լ� ������ ȣ��ǹǷ� CLazerSetActive���� ������ �Ҵ�Ǳ� ���� �����ϱ� ������ null�� �����ϱ� ���� �� ������ ���� �ڷ�ƾ ����
        yield return new WaitForEndOfFrame();

        float sumTime = 0f;

        float duringTime = StageManager.instance.noteMoveSpeed +
            StageManager.instance.notes[lazerSet.noteIdx].endTime - StageManager.instance.notes[lazerSet.noteIdx].srtTime;

        while (sumTime <= duringTime)
        {
            float t = sumTime / duringTime;
            circle.localScale = Vector3.Lerp(initialSize, targetSize, t);

            sumTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
