using System.Collections;
using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class RequestScene : MonoBehaviour
{
    private SkinnedMeshRenderer SMR;

    public GameObject Child;
    public GameObject Adult;

    public GameObject Plane;
    public GameObject LevelUp;

    public GameObject[] CFurniture;
    public GameObject[] AFurniture;

    private void Start()
    {
        SMR = GetComponent<SkinnedMeshRenderer>();

        Invoke("Grown", 6f);
        Invoke("RQScene", 7f);
    }

    void Grown()
    {
        StartCoroutine(Upgrade());
    }

    IEnumerator Upgrade()
    {
        Plane.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LevelUp.SetActive(true);
    }

    void RQScene()
    {
        StartCoroutine(CustomCoroutine());
    }

    IEnumerator CustomCoroutine()
    {
        yield return FaceControl.Instance.StartFaceControl(SMR, "angry_01", 0, 100, 1f);
        yield return FaceControl.Instance.StartFaceControl(SMR, "sad_01", 0, 100, 2f);
        yield return FaceControl.Instance.StartFaceControl(SMR, "angry_03", 0, 50, 1f);
        ChangeCharactor();
    }

    void ChangeCharactor()
    {
        Destroy(Child);
        SetActive(CFurniture, false);
        Adult.SetActive(true);
        SetActive(AFurniture, true);
    }

    public void SetActive(GameObject[] Array, bool isActive)
    {
        foreach (GameObject @object in Array)
        {
            if (@object != null)
            {
                @object.SetActive(isActive);
            }
        }
    }
}
