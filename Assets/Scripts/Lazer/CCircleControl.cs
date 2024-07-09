using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 레이저에 부착된 타이밍 표시용 원 아이콘을 활성화 시키는 스크립트 입니다.
/// </summary>
public class CCircleControl : MonoBehaviour
{
    public Transform circle; // 원 아이콘

    private float appearTime = 4f; // 원 아이콘이 줄어드는 시간
    public Vector3 targetSize; // 줄어들었을 때의 사이즈
    public Vector3 initialSize; // 원의 초기 사이즈

    private void OnEnable()
    {
        StartCoroutine(CircleSet());
    }

    IEnumerator CircleSet()
    {
        float sumTime = 0f;

        while (sumTime <= appearTime)
        {
            float t = sumTime / appearTime;
            circle.localScale = Vector3.Lerp(initialSize, targetSize, t);

            sumTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
}
