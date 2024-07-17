using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// Stage01에서 카메라의 움직임을 제어하는 스크립트입니다.
/// </summary>
public class CCameraMove : MonoBehaviour
{
    private float speed; // 초속

    private bool isIntroEnd; // 인트로 재생용 변수

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
