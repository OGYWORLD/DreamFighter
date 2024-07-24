using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class FaceStage2 : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();
        Invoke("Stage2FaceControl", 7f);
        Invoke("MakeMind", 9f);
    }
    
    void Stage2FaceControl()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 0f, 75f, 1f);
    }

    void MakeMind()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 75f, 0f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "angry_02", 0f, 30f, 1f);
        FaceControl.Instance.StartFaceControl(SMR, "happy_03", 0f, 10f, 1f);
    }
}