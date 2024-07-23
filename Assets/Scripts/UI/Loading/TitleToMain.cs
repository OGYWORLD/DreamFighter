using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#region ������
#endregion

public class TitleToMain : MonoBehaviour
{
    public const string ServerRoom = "02. Server Room";

    public AsyncOperation op;

    // Ÿ��Ʋ���� ���� ȭ������ ��ȯ�ϴ� ���� ����
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
