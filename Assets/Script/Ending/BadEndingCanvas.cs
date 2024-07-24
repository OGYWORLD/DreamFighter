using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class BadEndingCanvas : MonoBehaviour
{
    public Image Heart;
    public Image Blur;

    private void Start()
    {
        Invoke("Blink", 10f);
        Invoke("Blink2", 12f);
    }

    void Blink()
    {
        StartCoroutine(FadeHeart());
    }

    void Blink2()
    {
        StartCoroutine(FadeHeart2());
    }

    IEnumerator FadeHeart()
    {
        for (int i = 0; i < 3; i++)
        {
            FadeControl.Instance.StartFadeOut(Heart, 1f, 0f, 0.3f);
            yield return new WaitForSeconds(0.4f);
            FadeControl.Instance.StartFadeOut(Heart, 0f, 1f, 0.3f);
        }
    }

    IEnumerator FadeHeart2()
    {
        for (int i = 0; i < 3; i++)
        {
            FadeControl.Instance.StartFadeOut(Blur, 1f, 0f, 0.3f);
            yield return new WaitForSeconds(0.4f);
            FadeControl.Instance.StartFadeOut(Blur, 0f, 1f, 0.3f);
        }
    }
}