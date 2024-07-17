using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �������� ���Ժ� �κ� ī�޶� �����̴� ������ ���� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CIntroCamera : MonoBehaviour
{
    private Vector3 initPos = new Vector3(15.58f, 2.17f, 74.2f);
    private Quaternion initRotation = Quaternion.Euler (0f, -140.79f, 0f);

    private Vector3 targetPos = new Vector3(0.24f, 8.74f, 0f);
    private Quaternion targetRotation = Quaternion.Euler(34.42f, 90f, 0f);

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        float sumTime = 0f;
        float totalTime = 2f;
        while(sumTime <= totalTime)
        {
            float t = sumTime / totalTime;

            gameObject.transform.localPosition = Vector3.Lerp(initPos, targetPos, t);
            gameObject.transform.rotation = Quaternion.Lerp(initRotation, targetRotation, t);

            sumTime += Time.deltaTime;

            yield return null;
        }

        gameObject.transform.localPosition = targetPos;
        gameObject.transform.rotation = targetRotation;

        yield break;
    }
}
