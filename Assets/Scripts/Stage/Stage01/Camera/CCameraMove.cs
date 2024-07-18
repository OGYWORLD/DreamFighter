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
    protected float speed; // �ʼ�

    protected bool isIntroEnd; // ��Ʈ�� ����� ����

    protected virtual void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteRespawnTime);

        StartCoroutine(WaitIntro());
    }

    protected virtual void Update()
    {
        if(isIntroEnd)
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }  
    }

    protected IEnumerator WaitIntro()
    {
        yield return new WaitForSeconds(4f);

        isIntroEnd = true;
    }
}
