using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region ������
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

public class UIManager : Singleton<UIManager>
{
    // Ÿ��Ʋ���� �����, �ٷ� ���� ȭ������ ���� �����ϴ� ����
    public bool isMainLoadAgain = false;
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
    /// Inspector���� �Ҵ��� canvasList�� ������ canvasDic���� �Ű� ��� �޼���
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

        // �ٽ� �� �Ŷ�� clear, �ٽ� ���� ���� �Ŷ�� null
        canvasList = null;
    }

    public Canvas GetCVSByEnum(CanvasNamesEnum cvs)
    {
        return canvasDic[cvs];
    }
}
