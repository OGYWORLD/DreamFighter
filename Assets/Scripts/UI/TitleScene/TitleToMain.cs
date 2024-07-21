using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#region 우인혜
#endregion

public class TitleToMain : MonoBehaviour
{
    public const string ServerRoom = "02. Server Room";

    public Slider progressbar;

    public static bool isReadyToNextScene { get; set; } = false;


    private void Start()
    {
        //LoadMainScenesAsync();
        StartCoroutine(LoadMainSceneProcess());
        
    }

    IEnumerator LoadMainSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(ServerRoom);
        op.allowSceneActivation = false;

        float timer = 0f;

        while(!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressbar.value = op.progress;

            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressbar.value = Mathf.Lerp(0.9f, 1f, timer);

                if(progressbar.value >= 1f)
                {
                    progressbar.gameObject.SetActive(false);
                    break;
                }
            }
        }


        // todo: (인혜) 이 부분 조건 제대로 설정하기.
        // 주석처리하고 확인했을 때는 바로 전환됐다.
        yield return new WaitUntil(() => isReadyToNextScene);
        op.allowSceneActivation = true;
    }
}
