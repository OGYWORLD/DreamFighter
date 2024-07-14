using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region 우인혜
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
    /// 화면 페이지별로 구분해서 담을 리스트
    /// </summary>
    public List<Panels> PageList = new();

    /// <summary>
    /// 화면 영역별로 구분해서 담을 리스트
    /// </summary>
    public List<Panels> BoxList = new();

    public List<Buttons> ButtonList = new();

    public Canvas MainCanvas;
 
    public Dictionary<UIState, Action> stateDelegates = new();
    private UIState currentUIState;

    /// <summary>
    /// 델리게이트 등록
    /// </summary>
    public void RegisterDelegate(UIState state, Action action)
    {
        stateDelegates[state] = action;
    }

    /// <summary>
    /// 델리게이트 제거
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
