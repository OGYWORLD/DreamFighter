using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#region ¿ìÀÎÇý
#endregion

public class TitleToMain : MonoBehaviour
{
    public const string ServerRoom = "02. Server Room";

    public AsyncOperation op;


    private void Start()
    {
        StartCoroutine(LoadMainSceneProcess());
    }

    IEnumerator LoadMainSceneProcess()
    {
        op = SceneManager.LoadSceneAsync(ServerRoom);
        op.allowSceneActivation = false;

        yield return new WaitUntil(() => MainCanvasDictionary.Instance.isReadyTitleToMainScene);

        op.allowSceneActivation = true;
    }
}
