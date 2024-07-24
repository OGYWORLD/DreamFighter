using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class SciFiEmotion : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("FeelHappy", 17f);
        Invoke("MakeMind", 35f);
        Invoke("FindWay", 43.5f);
        Invoke("Surprised", 49f);
        Invoke("Fail", 52f);
    }

    void FeelHappy()
    {
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 0f, 50f, 3f);
    }

    void MakeMind()
    {
        FaceControl.Instance.StartFaceControl(SMR, "sad_01", 0f, 100f, 2f);
        FaceControl.Instance.StartFaceControl(SMR, "angry_01", 10f, 100f, 2f);
    }

    void FindWay()
    {
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 0f, 100f, 1f);
    }

    void Surprised()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 0f, 100f, 1f);
    }

    void Fail()
    {
        FaceControl.Instance.StartFaceControl(SMR, "happy_01", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 100f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "sad_03", 0f, 100f, 2f);
    }
}