using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class ApproachChest : MonoBehaviour
{
    private Animator Anim;
    public Image Black;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        CutScene();
        Invoke("Running", 2f);
        Invoke("Stop", 3.5f);
        Invoke("FadeOut", 9f);
    }

    void Running()
    {
        Anim.SetBool("isRunning", true);
    }

    void Stop()
    {
        Anim.SetBool("isRunning", false);
        Anim.SetTrigger("ToStop");
    }

    void CutScene()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 1f);
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 1f);
    }
}