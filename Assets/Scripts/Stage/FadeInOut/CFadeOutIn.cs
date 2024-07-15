using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 오가을
#endregion

/// <summary>
/// 스테이지 시작, 컷신 재생 전의 페이드 인/아웃을 구현한 스크립트 입니다.
/// </summary>
public class CFadeOutIn : MonoBehaviour
{
    public Image background;

    private void Start()
    {
        StartCoroutine(FadeInOut(1, 0));
    }

    public void Fade(int srt, int end)
    {
        StartCoroutine(FadeInOut(srt, end));
    }

    IEnumerator FadeInOut(int srt, int end)
    {
        float sumTime = 0f;
        float totalTime = 2f;

        while (sumTime <= totalTime)
        {
            float t = sumTime / totalTime;

            Color color = background.color;
            color.a = Mathf.Lerp(srt, end, sumTime / totalTime);
            background.color = color;

            sumTime += Time.deltaTime;

            yield return null;
        }

        if(srt == 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        yield break;
    }
}
