using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CCameraMove : MonoBehaviour
{
    private float betweenDis = 58f; // ������ ���� ��ġ�� ī�޶� ������ �Ÿ�

    private float speed; // �ʼ�

    private void Start()
    {
        speed = (betweenDis / StageManager.instance.noteMoveSpeed);
    }

    private void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);    
    }
}
