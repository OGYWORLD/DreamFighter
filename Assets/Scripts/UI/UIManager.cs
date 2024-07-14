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

[Serializable]
public class Panels
{
    public string name;
    public GameObject panel;
}

[Serializable]
public class Buttons
{
    public string name;
    public Button button;
}

public class UIManager : Singleton<UIManager>
{
    public bool isMainLoadAgain = false;

    //public GameObject TitleWorldObject;
    //public Dictionary<string, GameObject> WorldUIObjects = new();

    /// <summary>
    /// ȭ�� ���������� �����ؼ� ���� ����Ʈ
    /// </summary>
    public List<Panels> PageList = new();

    /// <summary>
    /// ȭ�� �������� �����ؼ� ���� ����Ʈ
    /// </summary>
    public List<Panels> BoxList = new();

    public List<Buttons> ButtonList = new();

    public Canvas MainCanvas;
 
    public Dictionary<UIState, Action> stateDelegates = new();
    private UIState currentUIState;

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
        if (stateDelegates.ContainsKey(currentUIState))
        {
            stateDelegates[currentUIState]?.Invoke();
        }

        yield return null;
    }

}
