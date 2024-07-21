using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CMoveAS : MonoBehaviour
{
    private float speed; // 초속

    private void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteRespawnTime);
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}
