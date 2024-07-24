using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region ±Ë«œ¿∫
#endregion

public class Day1Control : MonoBehaviour
{
    public Image White;
    public Image Black;
    public Image Logo;

    private void Start()
    {
        FadeControl.Instance.StartFadeOut(White, 1f, 0f, 0.5f);
        Invoke("EnterDream", 3.5f);
    }

    void EnterDream()
    {
        SceneManager.LoadScene("EnterDream");
    }
}