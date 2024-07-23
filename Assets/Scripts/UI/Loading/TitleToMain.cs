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

    public AsyncOperation op;

    // 타이틀에서 메인 화면으로 전환하는 시점 결정
    public bool isReadyTitleToMainScene { get; set; } = false;


    private void Start()
    {
        StartCoroutine(LoadMainSceneProcess());
    }

    IEnumerator LoadMainSceneProcess()
    {
        op = SceneManager.LoadSceneAsync(ServerRoom);
        op.allowSceneActivation = false;

        yield return new WaitUntil(() => isReadyTitleToMainScene);

        op.allowSceneActivation = true;
    }
}
