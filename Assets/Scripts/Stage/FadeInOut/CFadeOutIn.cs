using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

#region 오가을
#endregion

/// <summary>
/// 스테이지 시작, 컷신 재생 전의 페이드 인/아웃을 구현한 스크립트 입니다.
/// </summary>
public class CFadeOutIn : MonoBehaviour
{
    public Image background;

    public GameObject cutSceneCanvas; // 컷씬 캔버스
    public VideoPlayer cutScenePlayer; // 컷씬 비디오 플레이어

    private void Start()
    {
        StartCoroutine(FadeInOut(1, 0, 2));
    }

    public void Fade(int srt, int end, float time)
    {
        StartCoroutine(FadeInOut(srt, end, time));
    }

    public IEnumerator FadeInOut(int srt, int end, float totalTime)
    {
        if(srt == 1)
        {
            // 컷씬 비활성화
            cutScenePlayer.Stop();
            cutSceneCanvas.SetActive(false);
        }

        float sumTime = 0f;

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
            // 컷신 전환
            Time.timeScale = 1f;
            cutSceneCanvas.SetActive(true);
            cutScenePlayer.Play();
        }

        yield break;
    }
}
