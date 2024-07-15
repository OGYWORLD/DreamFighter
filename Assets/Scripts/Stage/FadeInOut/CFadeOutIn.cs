using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

/// <summary>
/// �������� ����, �ƽ� ��� ���� ���̵� ��/�ƿ��� ������ ��ũ��Ʈ �Դϴ�.
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
