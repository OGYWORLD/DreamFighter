using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 우인혜
#endregion

public enum ObjNames
{
    Start,
    Chat,
    Record,
    Info,
    Exit

    //,IndexCount
}

[Serializable]
public class WorldObjectInfo
{
    public ObjNames name;
    public GameObject WorldObject;
}

public class WorldObjectButton : MonoBehaviour
{
    public List<WorldObjectInfo> WorldBtnList = new();
    private Dictionary<ObjNames, GameObject> WorldBtnDic = new();
    private Dictionary<GameObject, ObjNames> ReverseDictionary = new();

    ObjNames e_ClickedObjectName;


    int layerMaskValue;

    //==============================================================================================


    private void Awake()
    {
        ListToDictionary();

        string[] layerNames = {"World Object Button"};
        layerMaskValue = LayerMask.GetMask(layerNames);
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
                ReverseDictionary[info.WorldObject] = info.name;
            }
            else
            {
                Debug.LogWarning($"동일한 이름 존재: {info.name}");
            }
        }

        WorldBtnList = null;
    }

    //private void EnumToString()
    //{
    //    int enumLength = (int)ObjNames.IndexCount - 1;

    //    ObjStringName = new string[enumLength];

    //    for(int i = 0; i < enumLength; i++)
    //    {
    //        ObjStringName[i] = ((ObjNames)i).ToString();
    //    }
    //}


    /// <summary>
    /// 마우스 왼쪽 버튼이 눌리는 경우에만 어느 오브젝트가 클릭되었는지 판별하는 일회성 코루틴을 실행시키는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator InputButtonCheckCoroutine()
    {
        while(true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            StartCoroutine(SortClickedButtonCoroutine());
        }
    }

    /// <summary>
    /// <seealso cref="Dictionary{TKey, TValue}<"/>의 key로 사용하기 위해 충돌 대상의 이름을 판별하는 코루틴  <br/>
    /// 이후 자동으로 다음 동작을 결정하는 코루틴 실행
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
            
            e_ClickedObjectName = (ObjNames)Enum.Parse(typeof(ObjNames), clickedObjectString);
        }

        SwitchActivateMethod();

        yield return null;
    }

    string FindKeyByValue(GameObject value)
    {
        if(ReverseDictionary.ContainsKey(value))
        {
            return ReverseDictionary[value].ToString();
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
            case ObjNames.Chat:
                ShowChat();
                break;

            case ObjNames.Record:
                ShowRecord();
                break;

            case ObjNames.Info:
                ShowInfo();
                break;

            case ObjNames.Exit:
                ShowExit();
                break;

            case ObjNames.Start:
                ShowStart();
                break;
        }
    }


    
    // 메서드에 코루틴을 담자~

    void ShowChat()
    {

    }

    void ShowRecord()
    {

    }

    void ShowInfo()
    {

    }

    void ShowExit()
    {
        print("나가는 문을 클릭했다!");
        // todo: 안 고쳐졌다. 정 안 되면 그냥 3D버튼 하나하나 스크립트 만들어 주자...

        // todo: (인혜) 종료 의사 확인 팝업 띄우기, Yes인 경우 종료화면 코루틴
    }

    void ShowStart()
    { 
        // todo: (인혜) 로딩화면 연결
    }


    // 이거 객체지향 맞나요... 점점 길어지기만 하는 스크립트.



    // 이건 잘 먹힌다...
    private void OnMouseEnter()
    {
        Debug.Log("버튼 영역에 마우스 들어왔다!");
    }

    private void OnMouseExit()
    {
        Debug.Log("마우스 치움!");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("처음 클릭했던 곳에서 클릭 해제!");
    }
}
