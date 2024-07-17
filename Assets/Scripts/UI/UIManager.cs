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

public enum CanvasNamesEnum
{
    BtnCVS,
    InfoCVS,

    PopupCVS,

    ChatCVS,
    RecordCVS,
    ScoreCVS

    , IndexCountCVS
   
}

[Serializable]
public class ElementsInCVS
{
    public string name;
    public GameObject obj;
}

[Serializable]
public class CanvasByEnumName
{
    public CanvasNamesEnum name;
    public Canvas canvas;
}

public class UIManager : Singleton<UIManager>
{
    // 씬을 전환할 때 활성화/비활성화하기 위해 참조
    public Camera UIMainCamera;

    // 타이틀부터 띄울지, 바로 메인 화면으로 들어갈지 결정하는 변수
    public bool isMainLoadAgain = false;

    public List<CanvasByEnumName> canvasList = new();
    public Dictionary<CanvasNamesEnum, Canvas> canvasDic = new();
    private Dictionary<Canvas, CanvasNamesEnum> ReverseCVSDic = new();

    public Canvas CurrentCanvas;
    public Canvas LastCanvas;

    private void Start()
    {
        InitCanvasDictionary();
    }

    /// <summary>
    /// Inspector에서 할당한 canvasList의 내용을 canvasDic으로 옮겨 담는 메서드
    /// </summary>
    void InitCanvasDictionary()
    {
        foreach (CanvasByEnumName canvasInfo in canvasList)
        {
            if (!canvasDic.ContainsKey(canvasInfo.name))
            {
                canvasDic.Add(canvasInfo.name, canvasInfo.canvas);
                ReverseCVSDic.Add(canvasInfo.canvas, canvasInfo.name);
            }
            else
            {
                Debug.LogWarning($"Duplicate canvas name found: { canvasInfo.name}");
            }
        }

        // 다시 쓸 거라면 clear, 다시 쓰지 않을 거라면 null
        canvasList = null;
    }

    public bool CheckCurrentAndNewCVSAreSame(CanvasNamesEnum name)
    {
        if(name == ReverseCVSDic[CurrentCanvas])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
