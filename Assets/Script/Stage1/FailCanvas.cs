using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class FailCanvas : MonoBehaviour
{
    public Image HeartBlur;
    public GameObject TextBox;
    public Image UI;

    private void Start()
    {
        Invoke("BaseSet", 0.9f);
        Invoke("Minus", 5f);
        Invoke("UIChange", 6.8f);
        Invoke("SwitchUI", 7f);
    }

    void BaseSet()
    {
        HeartBlur.gameObject.SetActive(true);
        UI.gameObject.SetActive(true);
    }

    void Minus()
    {
        StartCoroutine(MinusHeart());
    }

    private IEnumerator MinusHeart()
    {
        for (int i = 0; i < 2; i++)
        {
            FadeControl.Instance.StartFadeOut(HeartBlur, 1f, 0f, 0.3f);
            yield return new WaitForSeconds(0.5f);
            FadeControl.Instance.StartFadeOut(HeartBlur, 0f, 1f, 0.3f);
        }
    }

    void UIChange()
    {
        FadeControl.Instance.StartFadeOut(UI, 1f, 0f, 0f);
        FadeControl.Instance.StartFadeOut(HeartBlur, 1f, 0f, 0f);
    }

    void SwitchUI()
    {
        TextBox.SetActive(true);
    }
}