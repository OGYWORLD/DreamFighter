using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class SuccessStage2 : MonoBehaviour
{
    public Image Black;
    public GameObject Save;
    public GameObject Cursor;
    public GameObject Blank;

    private void Start()
    {
        CutScene();
        Cursor.SetActive(true);
        Invoke("SaveComp", 2f);
        Invoke("CanClick", 4f);
        Invoke("FadeOut", 11f);
    }

    void CutScene()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 2f);
    }

    void SaveComp()
    {
        Save.SetActive(true);
    }

    void CanClick()
    {
        Cursor.SetActive(false);
        Save.SetActive(false);
        Blank.SetActive(true);
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 1f);
    }
}