using System.Collections;
using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class RequestScene2 : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;
    public GameObject GameBoy;
    public GameObject Plane;
    public GameObject CharactorLight;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("RQScene", 4f);
        Invoke("ResetSMR", 9f);
        Invoke("MovePosition",9f);
        Invoke("Sleeping", 17f);
        Invoke("LightControl", 21f);
    }

    void RQScene()
    {
        StartCoroutine(CustomCoroutine());
    }

    void ResetSMR()
    {
        FaceControl.Instance.StartFaceControl(SMR,"sad_03", 100, 0, 0.5f);
        FaceControl.Instance.StartFaceControl(SMR,"sad_01", 0, 20, 0.5f);
        FaceControl.Instance.StartFaceControl(SMR,"angry_01", 100, 0, 0.5f);
        FaceControl.Instance.StartFaceControl(SMR,"happy_03", 100, 0, 0.5f);
    }

    IEnumerator CustomCoroutine()
    {
        yield return FaceControl.Instance.StartFaceControl(SMR,"angry_03", 100, 0, 0.5f);
        yield return FaceControl.Instance.StartFaceControl(SMR,"sad_03", 0, 100, 1.5f);
    }

    void Sleeping()
    {
        FaceControl.Instance.StartFaceControl(SMR,"eyes_closed.01", 0f, 100f, 2f);
        FaceControl.Instance.StartFaceControl(SMR,"eyes_closed.02", 0f, 30f, 2f);
    }

    void MovePosition()
    {
        GameBoy.SetActive(true);
    }

    void LightControl()
    {
        CharactorLight.SetActive(false);
        Invoke("LightControl2", 1.5f);
    }

    void LightControl2()
    {
        Plane.SetActive(true);
    }
}