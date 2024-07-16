using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 스테이지 도입부 카메라 움직임을 동작하는 스크립트 입니다.
/// </summary>
public class CCameraIntro : MonoBehaviour
{
    private Vector3 initPos = new Vector3(0.439999998f, 1.34000003f, 7.61999989f);
    private Vector3 targetPos = new Vector3(0.439999998f, 2.79999995f, 4.55999994f);

    private void OnEnable()
    {
        StartCoroutine(CameraMove());
    }

    IEnumerator CameraMove()
    {
        float sumTime = 0f;
        float totalTime = 2f;

        while(sumTime <= totalTime)
        {
            float t = sumTime / totalTime;
            gameObject.transform.localPosition = Vector3.Lerp(initPos, targetPos, t);

            sumTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
