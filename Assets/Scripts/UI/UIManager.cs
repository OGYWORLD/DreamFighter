using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region ������
#endregion

public enum UIState
{
    Enter,
    Main,
    Loading,
    InGame,
    Exit
}
// �˾��� ���� ���¿� �����ϰ� Ʈ���� �� �׻� �ݿ�.

public enum PageState
{
    Chat,
    Record,
    Info,
    Setting,
    Exit
}

public class UIManager : Singleton<UIManager>
{
    public Camera UIMainCamera;

    // �� ������ ������ �� Ÿ��Ʋ�� �����, �ٷ� ���� ȭ������ ���� �����ϴ� ����
    public bool isMainLoadAgain = false;

    //public GameObject TitleWorldObject;
    //public Dictionary<string, GameObject> WorldUIObjects = new();
 
    public Dictionary<UIState, Action> stateDelegates = new();
    private UIState CurrentUIState;


    private void OnEnable()
    {

    }


    /// <summary>
    /// ��������Ʈ ���
    /// </summary>
    public void RegisterDelegate(UIState state, Action action)
    {
        stateDelegates[state] = action;
    }

    /// <summary>
    /// ��������Ʈ ����
    /// </summary>
    /// <param name="state"></param>
    public void UnregisterDelegate(UIState state)
    {
        stateDelegates.Remove(state);
    }

    IEnumerator StateDelegateCoroutine()
    {
        if (stateDelegates.ContainsKey(CurrentUIState))
        {
            stateDelegates[CurrentUIState]?.Invoke();
        }

        yield return null;
    }

}
