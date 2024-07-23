using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#region 오가을
#endregion

public class CBeatCheck : MonoBehaviour
{
    public AudioSource beepSound;
    public AudioSource moveSound;

    public AudioClip finSound;

    public TextMeshProUGUI infoTMP;
    public TextMeshProUGUI resultTMP;

    public GameObject progress;

    public GameObject beatButtonObj;
    public GameObject resetButtonObj;
    private Animator beatButton;
    private Animator resetButton;

    private bool isChecking;
    private bool isAlreadyPush;
    private float checking = 0f;

    private int beepCount = 15;
    private float sumChecking = 0;

    private void Start()
    {
        beatButton = beatButtonObj.GetComponent<Animator>();
        resetButton = resetButtonObj.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!MenuManager.instance.isOpenMenu && isChecking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                float result = checking - Time.time;
                if (result < 0)
                {
                    if (result >= -0.6f)
                    {
                        sumChecking += (-result);
                    }
                    else
                    {
                        sumChecking += (-(1 + result));
                    }
                }
                else
                {
                    if (result <= 0.6f)
                    {
                        sumChecking += (-result);
                    }
                    else
                    {
                        sumChecking += (1 - result);
                    }
                }
            }
        }
    }

    public void OnClickBeatCheck()
    {
        if(!MenuManager.instance.isOpenMenu && !isAlreadyPush)
        {
            isAlreadyPush = true;
            StartCoroutine(BeatCheckSound());
        }
    }

    IEnumerator BeatCheckSound()
    {
        moveSound.Play();
        beatButton.SetTrigger("BeatCheck");
        resetButton.SetTrigger("BeatCheck");

        yield return new WaitForSeconds(0.5f);

        progress.SetActive(true);

        infoTMP.text = "삐- 소리에 맞추어 스페이스 바를 입력해 주세요.";

        yield return new WaitForSeconds(2f);

        isChecking = true;

        int index = 0;
        while (index < beepCount)
        {
            checking = Time.time;
            beepSound.Play();

            yield return new WaitForSeconds(0.9f);
            index++;
        }

        // 사운드
        beepSound.clip = finSound;
        beepSound.Play();

        isChecking = false;

        GameManager.instance.beatPadding = sumChecking / beepCount;

        progress.SetActive(false);

        infoTMP.text = "측정이 완료되었습니다.    메뉴화면으로 돌아갑니다.";

        if(GameManager.instance.beatPadding < 0)
        {
            resultTMP.text = "기존 보다 " + (-GameManager.instance.beatPadding) + "초 빠릅니다.";
        }
        else
        {
            resultTMP.text = "기존 보다 " + GameManager.instance.beatPadding + "초 느립니다.";
        }

        yield return new WaitForSeconds(3f);

        //메뉴화면으로 돌아가기
        SceneManager.LoadScene(1);
    }
}
