using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CCameraMove : MonoBehaviour
{
    private float betweenDis = 58f; // ������ ���� ��ġ�� ī�޶� ������ �Ÿ�
    private float lazerAprTime = 4f; // ������ ��ġ���� �̵��ϴ� �ð�

    private float speed; // �ʼ�

    private void Start()
    {
        speed = (betweenDis / lazerAprTime);
    }

    private void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);    
    }
}
