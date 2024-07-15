using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CCameraMove : MonoBehaviour
{
    private float speed; // 초속

    private void Start()
    {
        speed = (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);    
    }
}
