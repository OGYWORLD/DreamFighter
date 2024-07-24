using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class DaySMRclone : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("EndBow", 22f);
    }

    void EndBow()
    {
        FaceControl.Instance.StartFaceControl(SMR, "eyes_closed.01", 100f, 0f, 1f);
    }
}