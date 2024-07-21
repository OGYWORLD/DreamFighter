using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

#region ������
#endregion

/// <summary>
/// �������� ����, �ƽ� ��� ���� ���̵� ��/�ƿ��� ������ ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CFadeOutIn : MonoBehaviour
{
    public Image background;

    public GameObject cutSceneCanvas; // �ƾ� ĵ����
    public VideoPlayer cutScenePlayer; // �ƾ� ���� �÷��̾�

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
            // �ƾ� ��Ȱ��ȭ
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
            // �ƽ� ��ȯ
            Time.timeScale = 1f;
            cutSceneCanvas.SetActive(true);
            cutScenePlayer.Play();
        }

        yield break;
    }
}
