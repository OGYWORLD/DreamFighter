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
// 그런데 이걸 디자인 패턴을 써서 만들 자신이 있니...
// 일단 그냥 되는 대로 연결해 보자.

[Serializable]
public class CanvasByString
{
    public string name;
    public Canvas canvas;
}

public class UIManager : Singleton<UIManager>
{
    // 씬을 전환할 때 활성화/비활성화하기 위해 참조
    public Camera UIMainCamera;

    // 이 씬으로 들어왔을 때 타이틀을 띄울지, 바로 메인 화면으로 들어갈지 결정하는 변수
    public bool isMainLoadAgain = false;

    // 델리게이트
    //public Dictionary<UIState, Action> stateDelegates = new();
    //private UIState CurrentUIState;

    public List<CanvasByString> canvasList = new List<CanvasByString>();
    public Dictionary<string, Canvas> canvasDic = new Dictionary<string, Canvas>();

    private void Start()
    {
        InitCanvasDictionary();

        

        

        //테스트 성공
        //canvasDic[canvasList[1].name].gameObject.SetActive(true);
    }

    /// <summary>
    /// Inspector에서 할당한 canvasList의 내용을 canvasDic으로 옮겨 담는 메서드
    /// </summary>
    void InitCanvasDictionary()
    {
        foreach (CanvasByString canvasInfo in canvasList)
        {
            if (!canvasDic.ContainsKey(canvasInfo.name))
            {
                canvasDic.Add(canvasInfo.name, canvasInfo.canvas);
            }
            else
            {
                Debug.LogWarning($"Duplicate canvas name found: { canvasInfo.name}");
            }
        }

        // 다시 쓸 거라면 clear, 다시 쓰지 않을 거라면 null
        canvasList = null;

    }


    //private void CheckCurrentState()
    //{
    //    switch (CurrentUIState)
    //    {
    //        case UIState.Enter:
    //            break;

    //        case UIState.Main:
    //            break;

    //        case UIState.Loading:
    //            break;

    //        case UIState.InGame:
    //            break;

    //        case UIState.Exit:
    //            break;

    //        default: print("UI상태 체크 오류");
    //            break;
    //    }
    //}


    #region 델리게이트...
    /*
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
     
     
     */

    #endregion

}
