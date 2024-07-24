using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class DayAnimation : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Invoke("Anyway", 9f);
    }

    void Anyway()
    {
        Anim.SetTrigger("Anyway");
    }
}