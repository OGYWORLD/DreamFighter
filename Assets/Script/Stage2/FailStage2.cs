using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class FailStage2 : MonoBehaviour
{
    public Image Black;
    public GameObject BlueScreen;
    public GameObject Error;
    public GameObject Screen;
    public GameObject[] MiniErrors;
    public int SlowCut = 4;
    public float SlowTime = 0.5f;
    public float FastTime = 0.1f;

    private void Start()
    {
        Error.SetActive(true);
        CutScene();
        Invoke("FirstError", 1f);
        StartCoroutine(CoroutineDelay(ActiveCoroutine(), 2f));
        Invoke("HugeError", 5f);
        Invoke("Active", 5f);
        Invoke("FadeOut", 11f);
    }

    void CutScene()
    {
        FadeControl.Instance.StartFadeOut(Black, 1f, 0f, 2f);
    }

    void FirstError()
    {
        Screen.SetActive(false);
    }

    IEnumerator ActiveCoroutine()
    {
        for (int i = 0; i < MiniErrors.Length; i++)
        {
            if (i < SlowCut)
            {
                yield return new WaitForSeconds(SlowTime);
            }

            else
            {
                yield return new WaitForSeconds(FastTime);
            }

            MiniErrors[i].SetActive(true);
        }
    }

    void HugeError()
    {
        BlueScreen.SetActive(true);
    }

    IEnumerator CoroutineDelay(IEnumerator Coroutine, float Delay)
    {
        yield return new WaitForSeconds(Delay);
        StartCoroutine(Coroutine);
    }

    void Active()
    {
        SetActive(MiniErrors, false);
    }

    void SetActive(GameObject[] Array, bool isActive)
    {
        foreach (GameObject @object in Array)
        {
            if (@object != null)
            {
                @object.SetActive(isActive);
            }
        }
    }

    void FadeOut()
    {
        FadeControl.Instance.StartFadeOut(Black, 0f, 1f, 1f);
    }
}