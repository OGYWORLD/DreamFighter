using UnityEngine;

#region ������
#endregion

public class ChangeAnimation : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        ChangeAnim();
    }

    public void ChangeAnim()
    {
        Anim.SetTrigger("isPlaying");
    }
}
