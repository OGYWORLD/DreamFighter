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
// �׷��� �̰� ������ ������ �Ἥ ���� �ڽ��� �ִ�...
// �ϴ� �׳� �Ǵ� ��� ������ ����.

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
    public ElementsInCVS[] Elements;
}

public class UIManager : Singleton<UIManager>
{
    // ���� ��ȯ�� �� Ȱ��ȭ/��Ȱ��ȭ�ϱ� ���� ����
    public Camera UIMainCamera;

    // Ÿ��Ʋ���� �����, �ٷ� ���� ȭ������ ���� �����ϴ� ����
    public bool isMainLoadAgain = false;

    // ��������Ʈ
    //public Dictionary<UIState, Action> stateDelegates = new();
    //private UIState CurrentUIState;

    public List<CanvasByEnumName> canvasList = new();
    public Dictionary<CanvasNamesEnum, Canvas> canvasDic = new();

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
            if (!canvasDic.ContainsKey(canvasInfo.name))
            {
                canvasDic.Add(canvasInfo.name, canvasInfo.canvas);
            }
            else
            {
                Debug.LogWarning($"Duplicate canvas name found: { canvasInfo.name}");
            }
        }

        // �ٽ� �� �Ŷ�� clear, �ٽ� ���� ���� �Ŷ�� null
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

    //        default: print("UI���� üũ ����");
    //            break;
    //    }
    //}


    #region ��������Ʈ...
    /*
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
     
     
     */

    #endregion

}
