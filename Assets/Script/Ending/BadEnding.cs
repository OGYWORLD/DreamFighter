using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class BadEnding : MonoBehaviour
{
    private Animator Anim;
    public Image Black;
    public GameObject BadEnd;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        FadeIn();
        Invoke("Crying", 8f);
        Invoke("FadeOut", 13f);
        Invoke("BadEndLogo", 14f);
    }

    void FadeIn()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 1.5f);
    }

    void Crying()
    {
        Anim.SetTrigger("isBad");
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 2f);
    }

    void BadEndLogo()
    {
        BadEnd.SetActive(true);
    }
}