using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CCameraMove : MonoBehaviour
{
    private float speed; // �ʼ�

    private void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);    
    }
}
