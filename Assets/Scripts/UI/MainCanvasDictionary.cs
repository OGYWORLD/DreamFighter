using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region 우인혜
#endregion

public enum CanvasNamesEnum
{
    BtnCVS,
    TitleInfoCVS,

    PopupExitCVS,

    SettingCVS,
    ChatCVS,
    RecordCVS,
    ScoreCVS,

    MainMenuInfoCVS

    , IndexCountCVS
   
}

[Serializable]
public class CanvasByEnumName
{
    public CanvasNamesEnum name;
    public Canvas canvas;
}

public class MainCanvasDictionary : MonoBehaviour
{
    private static MainCanvasDictionary instance;

    public static MainCanvasDictionary Instance
    {
        get
        {
            instance = FindObjectOfType<MainCanvasDictionary>();

            if (instance == null)
            {
                GameObject obj = new("MainCanvasDictionary");
                instance = obj.AddComponent<MainCanvasDictionary>();
            }
            
            return instance;
        }
    }


    // 타이틀부터 띄울지, 바로 메인 화면으로 들어갈지 결정하는 변수
    public bool isMainLoadAgain = false;

    // 타이틀에서 메인 화면으로 전환하는 시점 결정
    public bool isReadyTitleToMainScene = false;

    public List<CanvasByEnumName> canvasList = new();
    public Dictionary<CanvasNamesEnum, Canvas> canvasDic = new();
    private Dictionary<Canvas, CanvasNamesEnum> ReverseCVSDic = new();

    public Canvas CurrentCanvas;
    

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
            if (!canvasDic.ContainsKey(canvasInfo.name) && !canvasDic.ContainsValue(canvasInfo.canvas))
            {
                canvasDic.Add(canvasInfo.name, canvasInfo.canvas);
                ReverseCVSDic.Add(canvasInfo.canvas, canvasInfo.name);
            }
            else
            {
                Debug.LogWarning($"Duplicate found: { canvasInfo.name}");
            }
        }

        // 다시 쓸 거라면 clear, 다시 쓰지 않을 거라면 null
        canvasList = null;
    }

    public Canvas GetCVSByEnum(CanvasNamesEnum cvs)
    {
        return canvasDic[cvs];
    }
}
