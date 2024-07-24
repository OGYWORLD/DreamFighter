using UnityEngine;

#region ������
#endregion

public class AnimationStage2 : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        Invoke("FistUp", 9f);
    }

    void FistUp()
    {
        Anim.SetTrigger("Fist");
    }
}