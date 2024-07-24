using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class HeroAnim : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        Invoke("Act", 71f);
    }

    void Act()
    {
        Anim.SetTrigger("Appear");
    }
}