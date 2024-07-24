using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class GoodEndingSMR : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("Surprised", 6f);
    }

    void Surprised()
    {
        FaceControl.Instance.StartFaceControl(SMR, "surprised_01", 0f, 70f, 0.8f);
    }
}