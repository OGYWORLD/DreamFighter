using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// Stage01���� ī�޶��� �������� �����ϴ� ��ũ��Ʈ�Դϴ�.
/// </summary>
public class CCameraMove : MonoBehaviour
{
    private float speed; // �ʼ�

    private bool isIntroEnd; // ��Ʈ�� ����� ����

    private void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed);

        StartCoroutine(WaitIntro());
    }

    private void Update()
    {
        if(isIntroEnd)
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }  
    }

    IEnumerator WaitIntro()
    {
        yield return new WaitForSeconds(4f);

        isIntroEnd = true;
    }
}
