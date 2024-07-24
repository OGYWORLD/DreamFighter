using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class CanvasControl : MonoBehaviour
{
    public GameObject Cut1;
    public GameObject Cut2;
    public GameObject Cut3;

    private void Start()
    {
        Invoke("FirstCut", 66.5f);
        Invoke("SecondCut", 67.5f);
        Invoke("ThirdCut", 68.5f);
        Invoke("FullShot", 71f);
    }

    void FirstCut()
    {
        Cut1.SetActive(true);
    }

    void SecondCut()
    {
        Cut2.SetActive(true);
    }

    void ThirdCut()
    {
        Cut3.SetActive(true);
    }

    void FullShot()
    {
        Cut1.SetActive(false);
        Cut2.SetActive(false);
        Cut3.SetActive(false);
    }
}