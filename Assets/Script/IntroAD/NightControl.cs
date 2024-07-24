using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region ������
#endregion

public class NightControl : MonoBehaviour
{
    public Image Black;

    private void Start()
    {
        Invoke("FadeOut", 3f);
        Invoke("Day", 10f);
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 2f);
    }

    void Day()
    {
        SceneManager.LoadScene("Day");
    }
}