using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CMoveAS : MonoBehaviour
{
    private float speed; // �ʼ�

    private void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteRespawnTime);
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}
