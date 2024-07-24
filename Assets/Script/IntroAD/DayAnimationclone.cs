using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class DayAnimationclone : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        Invoke("Talking", 17f);
        Invoke("MakeBow", 21f);
    }

    void MakeBow()
    {
        Anim.SetTrigger("Bow");
    }

    void Talking()
    {
        Anim.SetTrigger("Talk");
    }
}