using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoveAS : MonoBehaviour
{
    private float speed; // √ º”

    private void Start()
    {
        StageManager.instance.betweenDis = 20f;
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed);
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}
