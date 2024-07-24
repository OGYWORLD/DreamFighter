using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class BadEndingSMR : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("Surprised", 6f);
        Invoke("FeelSad", 7.5f);
    }

    void Surprised()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 20f, 100f, 1f);
    }

    void FeelSad()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 100f, 0f, 0f);
        FaceControl.Instance.StartFaceControl(SMR, "sad_03", 0f, 100f, 1f);
    }
}