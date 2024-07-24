using System.Collections;
using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class FailStage : MonoBehaviour
{
    private Animator Anim;
    public SkinnedMeshRenderer SMR;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Invoke("FeelSad", 7f);
        Invoke("Fail", 7f);
    }

    void Fail()
    {
        Anim.SetTrigger("Fail");
    }

    void FeelSad()
    {
        FaceControl.Instance.StartFaceControl(SMR, "happy_03", 70f, 25f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "sad_01", 0f, 100f, 1f);
    }
}
