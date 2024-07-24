using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class HeroFaceControl : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("LookUp", 69.5f);
        Invoke("Common", 71f);
    }

    void LookUp()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.L", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.R", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.L", 0f, 45f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.R", 0f, 45f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 0f, 35f, 1f);
    }

    void Common()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.L", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.R", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.L", 45f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.R", 45f, 0f, 1f);
    }
}