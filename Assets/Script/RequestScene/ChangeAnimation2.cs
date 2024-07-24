using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class ChangeAnimation2 : MonoBehaviour
{
    private Animator Anim;

    public Vector3 NewPosition;
    public Vector3 NewRotation;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        ChangeAnim();
        Invoke("ChangeAnim2", 4f);
        Invoke("ChangeAnim3", 10f);
    }

    void ChangeAnim()
    {
        Anim.SetTrigger("isPlaying");
    }

    void ChangeAnim2()
    {
        Anim.SetLayerWeight(1, 0.8f);
        Anim.SetTrigger("isDefeat");
    }

    void ChangeAnim3()
    {
        transform.localPosition = NewPosition;
        transform.localRotation = Quaternion.Euler(NewRotation);

        Anim.SetLayerWeight(1, 0f);
        Anim.SetTrigger("isLying");
    }
}