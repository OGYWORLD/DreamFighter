using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class SuccessCanvas : MonoBehaviour
{
    public Image ObjectBlur;
    public Image PlusUI;
    public Image UI;
    public GameObject TextBox;

    private void Start()
    {
        Invoke("BaseSet", 0.9f);
        Invoke("Blur", 4f);
        Invoke("UpgradeUI", 4f);
        Invoke("ChangeUI", 6.8f);
        Invoke("SwitchUI", 7f);
    }

    void BaseSet()
    {
        ObjectBlur.gameObject.SetActive(true);
        PlusUI.gameObject.SetActive(true);
        UI.gameObject.SetActive(true);
    }

    void Blur()
    {
        StartCoroutine(GameBoyFade());
    }

    IEnumerator GameBoyFade()
    {
        for (int i = 0; i < 3; i++)
        {
            FadeControl.Instance.StartFadeOut(ObjectBlur, 0f, 1f, 0.3f);
            yield return new WaitForSeconds(0.2f);
            FadeControl.Instance.StartFadeOut(ObjectBlur, 1f, 0f, 0.3f);
        }
    }

    void UpgradeUI()
    {
        StartCoroutine(UIUpgrade());
    }

    IEnumerator UIUpgrade()
    {
        FadeControl.Instance.StartFadeOut(PlusUI, 0f, 1f, 1f);
        yield return new WaitForSeconds(1f);
        FadeControl.Instance.StartFadeOut(UI, 1f, 0f, 0f);
    }

    void ChangeUI()
    {
        FadeControl.Instance.StartFadeOut(PlusUI, 1f, 0f, 0f);
        FadeControl.Instance.StartFadeOut(ObjectBlur, 1f, 0f, 0f);
    }

    void SwitchUI()
    {
        TextBox.SetActive(true);
    }

}