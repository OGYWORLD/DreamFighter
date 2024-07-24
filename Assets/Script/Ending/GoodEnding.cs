using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class GoodEnding : MonoBehaviour
{
    public Image Black;
    public Image Finish;
    public GameObject Background;
    public GameObject PopUp;
    public GameObject Complete;
    public GameObject Cursor;
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        FadeIn();
        Invoke("Change", 5f);
        Invoke("Appear", 7.5f);
        Invoke("Final", 9f);
        Invoke("Last", 10.5f);
        Invoke("End", 11.5f);
    }

    void FadeIn()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 1f);
    }

    void Change()
    {
        Background.SetActive(true);
        Cursor.SetActive(true);
    }

    void Appear()
    {
        PopUp.SetActive(true);
        Anim.enabled = false;
    }

    void Final()
    {
        Cursor.SetActive(false);
        Complete.SetActive(true);
    }

    void Last()
    {
        FadeControl.Instance.StartFadeOut(Finish, 0f, 1f, 3f);
    }

    void End()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 2f);
    }
}