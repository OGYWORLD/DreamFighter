using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class DaySMR : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("Well", 1f);
        Invoke("Blink", 6.8f);
        Invoke("SometimesItFails", 7f);
        Invoke("LookUp", 11.5f);
        Invoke("MouthSmile", 13f);
    }

    void Well()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.L", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.R", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_down.L", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_down.R", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 50f, 5f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_02", 15f, 5f, 1f);
    }

    void Blink()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eyes_closed.01", 100f, 0f, 1f);
    }

    void SometimesItFails()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.L", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_right.R", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_down.L", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_down.R", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 5f, 50f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_02", 5f, 15f, 1f);
    }

    void LookUp()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_left.L", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_left.R", 0f, 100f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.L", 0f, 50f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "eye_look_up.R", 0f, 50f, 1f);
    }

    void MouthSmile()
    {
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 50f, 100f, 1f);
    }
}