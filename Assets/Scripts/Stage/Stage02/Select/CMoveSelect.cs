using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CMoveSelect : MonoBehaviour
{
    private float speed; // �ʼ�

    private void Start()
    {
        StageManager.instance.betweenDis = 4.802f;
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed);
    }

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
}
