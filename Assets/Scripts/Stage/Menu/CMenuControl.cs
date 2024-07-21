using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CMenuControl : MonoBehaviour
{
    public GameObject menuCanvas;
    public AudioSource mainBGM;

    public GameObject[] ThreeTwoOne;

    public AudioSource menuAS;
    public AudioSource countAS;
    public AudioClip finalSound;
    public AudioClip countSound;

    private void Update()
    {
        if (!StageManager.instance.isPlayingCutScene && Input.GetKeyDown(KeyCode.Tab))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        if (!menuCanvas.activeSelf)
        {
            // �޴� ����
            menuAS.Play();
            menuCanvas.SetActive(true);
            mainBGM.Pause();
            Time.timeScale = 0f;
        }
        else if (menuCanvas.activeSelf)
        {
            // �޴� �ݱ�
            menuCanvas.SetActive(false);
            StartCoroutine(CountThreeTwoOne());
        }
    }

    IEnumerator CountThreeTwoOne()
    {
        for(int i = ThreeTwoOne.Length-1; i > -1; i--)
        {
            if(i == 0)
            {
                countAS.clip = finalSound;
            }
            countAS.Play();
            ThreeTwoOne[i].SetActive(true);

            yield return new WaitForSecondsRealtime(1f);

            ThreeTwoOne[i].SetActive(false);
        }

        countAS.clip = countSound;
        mainBGM.UnPause();
        Time.timeScale = 1f;

        yield break;
    }
}
