using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class SciFade : MonoBehaviour
{
    public Image Black;
    public Image StartIcon;

    private void Start()
    {
        StartCoroutine(Blink());
        Invoke("BlinkTwice", 6f);
        Invoke("FadeOut", 26f);
        Invoke("FadeIn", 29f);
        Invoke("GetStart", 72f);
        Invoke("ReFade", 73f);
    }

    void BlinkTwice()
    {
        StartCoroutine(Blink2());
    }

    IEnumerator Blink()
    {
        yield return FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 3f);
        yield return FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 1f);
        yield return FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 3f);
    }

    IEnumerator Blink2()
    {
        yield return FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 1f);
        yield return FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 3f);
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 2f);
    }

    void FadeIn()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 2f);
    }

    void ReFade()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 2f);
    }

    void GetStart()
    {
        FadeControl.Instance.StartFadeOut(StartIcon, 0f, 1f, 2f);
    }
}