using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class DayControl : MonoBehaviour
{
    public Image Black;
    public Image Black2;
    public Image Logo;

    private void Start()
    {
        Invoke("LogoOpen", 26f);
        Invoke("FadeOut", 28f);
        Invoke("AllBlack", 30f);
    }

    void LogoOpen()
    {
        FadeControl.Instance.StartFadeOut(Logo, 0f, 1f, 2f);
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 3f);
    }

    void AllBlack()
    {
        FadeControl.Instance.StartFadeOut(Black2, 0f, 1f, 2f);
    }
}