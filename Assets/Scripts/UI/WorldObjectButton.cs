using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

#region 우인혜
#endregion

public enum ObjBtnNames
{
    Start,
    Setting,
    Record,
    Exit

    ,IndexCount // 정해진 오브젝트 외의 클릭을 처리하는 경우에도 활용 중
}

/// <summary>
/// 인스펙터에서 List로 담을 버튼용 3D 오브젝트 정보
/// </summary>
[Serializable]
public class WorldObjectInfo
{
    public ObjBtnNames name;
    public GameObject WorldObject;
}

public class WorldObjectButton : MonoBehaviour
{
    public List<WorldObjectInfo> WorldBtnList = new();
    private Dictionary<ObjBtnNames, GameObject> WorldBtnDic = new();
    private Dictionary<GameObject, ObjBtnNames> ReverseWBtnDic = new();

    ObjBtnNames e_ClickedObjectName;


    int layerMaskValue;

    //==============================================================================================


    private void Awake()
    {
        ListToDictionary();

        string[] layerNames = {"World Object Button"};
        layerMaskValue = LayerMask.GetMask(layerNames);

        e_ClickedObjectName = ObjBtnNames.IndexCount;
    }

    private void Start()
    {
        StartCoroutine(InputButtonCheckCoroutine());
    }

    //==============================================================================================


    /// <summary>
    /// 인스펙터를 통해 List에 저장된 정보를 Dictionary로 옮겨 담는 메서드
    /// </summary>
    private void ListToDictionary()
    {
        foreach(WorldObjectInfo info in WorldBtnList)
        {
            if(!WorldBtnDic.ContainsKey(info.name))
            {
                WorldBtnDic[info.name] = info.WorldObject;
                ReverseWBtnDic[info.WorldObject] = info.name;
            }
            else
            {
                Debug.LogWarning($"동일한 이름 존재: {info.name}");
            }
        }

        WorldBtnList = null;

        //print("리스트에서 딕셔너리로 옮겨 담음");
    }


    /// <summary>
    /// 마우스 왼쪽 버튼이 눌리는 경우에만 어느 오브젝트가 클릭되었는지 판별하는 일회성 코루틴을 실행시키는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator InputButtonCheckCoroutine()
    {
        //print("InputButtonCheckCoroutine 실행됨");

        while(true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject());

            StartCoroutine(SortClickedButtonCoroutine());

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        }
    }


    /// <summary>
    /// 클릭된 버튼 오브젝트에 따라 자동으로 다음 동작을 결정하는 코루틴
    /// </summary>
    IEnumerator SortClickedButtonCoroutine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        // Physics.Raycast(Ray, out hitInfo)는 true 또는 false를 반환한다.
        // Ray의 충돌 정보를 찾았는지 판별하는 메서드이기 때문이다.
        // 참인 경우 대상을 찾았다는 뜻이고, out 키워드로 충돌 정보가 담긴 채 꺼내진 hitInfo 변수를 활용해
        // 충돌 대상이 어떤 오브젝트인지 그 정보를 반환한다.
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMaskValue))
        {
            GameObject clickedObject = hitInfo.collider.gameObject;

            string clickedObjectString = FindKeyByValue(clickedObject);
            
            e_ClickedObjectName = (ObjBtnNames)Enum.Parse(typeof(ObjBtnNames), clickedObjectString);

            //Debug.Log("SortClickedButtonCoroutine 실행됨");
        }
        else
        {
            // 한 번 할당된 값이 그대로 유지되어 올바른 대상 이외의 클릭에서도 계속 쓰이는 것을 막기 위해 초기화
            e_ClickedObjectName = ObjBtnNames.IndexCount;
        }

        SwitchActivateMethod();

        yield return null;
    }

    /// <summary>
    /// WorldBtnDic의 키와 값을 반대로 매핑한 ReverseWBtnDic에서 WorldBtnDic의 키를 찾아 주는 메서드. <br/>
    /// 이 방법을 쓰면 메모리는 조금 더 쓰지만 Dictionary 자체는 기본적으로 시간 복잡도가 낮고, 중복 요소 체크가 용이함.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    string FindKeyByValue(GameObject value)
    {
        if(ReverseWBtnDic.ContainsKey(value))
        {
            return ReverseWBtnDic[value].ToString();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 버튼으로 활용되는 3D 오브젝트 중 어느 것이 눌렸는지에 따라 각각 다른 메서드 실행
    /// </summary>
    void SwitchActivateMethod()
    {
        switch (e_ClickedObjectName)
        {
            case ObjBtnNames.Setting:
                ShowSetting();
                break;

            case ObjBtnNames.Record:
                ShowRecord();
                break;

            case ObjBtnNames.Exit:
                ShowExit();
                break;

            case ObjBtnNames.Start:
                ShowStart();
                break;

            default:
                // do nothing
                CloseCurrentCanvas();
                // todo: (인혜) UI 영역 바깥쪽을 클릭했을 때 열려 있던 캔버스가 비활성화되게끔
                break;
        }
    }


    
    // todo: (인혜) 메서드에 코루틴을 담자!

    void ShowSetting()
    {
        if(UIManager.Instance.CheckCurrentAndNewCVSAreSame(CanvasNamesEnum.SettingCVS))
        {
            return;
        }

        SetCurrentCanvas(CanvasNamesEnum.SettingCVS);
        OpenCurrentCanvas();
    }

    void ShowStart()
    {
        if (UIManager.Instance.CheckCurrentAndNewCVSAreSame(CanvasNamesEnum.ChatCVS))
        {
            return;
        }

        SetCurrentCanvas(CanvasNamesEnum.ChatCVS);
        OpenCurrentCanvas();
    }

    void ShowExit()
    {
        if (UIManager.Instance.CheckCurrentAndNewCVSAreSame(CanvasNamesEnum.PopupCVS))
        {
            return;
        }

        SetCurrentCanvas(CanvasNamesEnum.PopupCVS);
        OpenCurrentCanvas();

        print("나가는 문을 클릭했다!");

        // todo: (인혜) 종료 의사 확인 팝업 띄우기, Yes인 경우 종료화면 코루틴
    }

    void ShowRecord()
    {
        print("기록 열람");
        // todo: (인혜) 로딩화면 연결
    }

    void CloseCurrentCanvas()
    {
        if(UIManager.Instance.CurrentCanvas == null)
        {
            return;
        }
        else
        {
            UIManager.Instance.CurrentCanvas.gameObject.SetActive(false);
            // todo : (인혜) CurrentCanvas 체크하는 함수 만들기... 그리고 이 위치에서 기본 UI 캔버스 활성화시키기
        }


        print("열려 있던 캔버스 닫기");
    }

    void OpenCurrentCanvas()
    {
        UIManager.Instance.CurrentCanvas.gameObject.SetActive(true);
    }

    void OpenTargetCanvas(CanvasNamesEnum name)
    {
        UIManager.Instance.canvasDic[name].gameObject.SetActive(true);
    }

    void SetCurrentCanvas(CanvasNamesEnum name)
    {
        UIManager.Instance.CurrentCanvas = UIManager.Instance.canvasDic[name];
    }

    void SetTargetCanvas(CanvasNamesEnum name, bool b)
    {
        UIManager.Instance.canvasDic[name].gameObject.SetActive(b);
    }

}