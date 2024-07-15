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
// 팝업은 현재 상태와 무관하게 트리거 시 항상 반영.

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

    // 이 씬으로 들어왔을 때 타이틀을 띄울지, 바로 메인 화면으로 들어갈지 결정하는 변수
    public bool isMainLoadAgain = false;

    //public GameObject TitleWorldObject;
    //public Dictionary<string, GameObject> WorldUIObjects = new();
 
    public Dictionary<UIState, Action> stateDelegates = new();
    private UIState CurrentUIState;


    private void OnEnable()
    {

    }


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
        if (stateDelegates.ContainsKey(CurrentUIState))
        {
            stateDelegates[CurrentUIState]?.Invoke();
        }

        yield return null;
    }

}
