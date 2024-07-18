using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

#region ������
#endregion

public enum ObjBtnNames
{
    Start,
    Setting,
    Record,
    Exit

    ,IndexCount // ������ ������Ʈ ���� Ŭ���� ó���ϴ� ��쿡�� Ȱ�� ��
}

/// <summary>
/// �ν����Ϳ��� List�� ���� ��ư�� 3D ������Ʈ ����
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
    /// �ν����͸� ���� List�� ����� ������ Dictionary�� �Ű� ��� �޼���
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
                Debug.LogWarning($"������ �̸� ����: {info.name}");
            }
        }

        WorldBtnList = null;

        //print("����Ʈ���� ��ųʸ��� �Ű� ����");
    }


    /// <summary>
    /// ���콺 ���� ��ư�� ������ ��쿡�� ��� ������Ʈ�� Ŭ���Ǿ����� �Ǻ��ϴ� ��ȸ�� �ڷ�ƾ�� �����Ű�� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator InputButtonCheckCoroutine()
    {
        //print("InputButtonCheckCoroutine �����");

        while(true)
        {
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject());

            StartCoroutine(SortClickedButtonCoroutine());

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        }
    }


    /// <summary>
    /// Ŭ���� ��ư ������Ʈ�� ���� �ڵ����� ���� ������ �����ϴ� �ڷ�ƾ
    /// </summary>
    IEnumerator SortClickedButtonCoroutine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        // Physics.Raycast(Ray, out hitInfo)�� true �Ǵ� false�� ��ȯ�Ѵ�.
        // Ray�� �浹 ������ ã�Ҵ��� �Ǻ��ϴ� �޼����̱� �����̴�.
        // ���� ��� ����� ã�Ҵٴ� ���̰�, out Ű����� �浹 ������ ��� ä ������ hitInfo ������ Ȱ����
        // �浹 ����� � ������Ʈ���� �� ������ ��ȯ�Ѵ�.
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMaskValue))
        {
            GameObject clickedObject = hitInfo.collider.gameObject;

            string clickedObjectString = FindKeyByValue(clickedObject);
            
            e_ClickedObjectName = (ObjBtnNames)Enum.Parse(typeof(ObjBtnNames), clickedObjectString);

            //Debug.Log("SortClickedButtonCoroutine �����");
        }
        else
        {
            // �� �� �Ҵ�� ���� �״�� �����Ǿ� �ùٸ� ��� �̿��� Ŭ�������� ��� ���̴� ���� ���� ���� �ʱ�ȭ
            e_ClickedObjectName = ObjBtnNames.IndexCount;
        }

        SwitchActivateMethod();

        yield return null;
    }

    /// <summary>
    /// WorldBtnDic�� Ű�� ���� �ݴ�� ������ ReverseWBtnDic���� WorldBtnDic�� Ű�� ã�� �ִ� �޼���. <br/>
    /// �� ����� ���� �޸𸮴� ���� �� ������ Dictionary ��ü�� �⺻������ �ð� ���⵵�� ����, �ߺ� ��� üũ�� ������.
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
    /// ��ư���� Ȱ��Ǵ� 3D ������Ʈ �� ��� ���� ���ȴ����� ���� ���� �ٸ� �޼��� ����
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
                // todo: (����) UI ���� �ٱ����� Ŭ������ �� ���� �ִ� ĵ������ ��Ȱ��ȭ�ǰԲ�
                break;
        }
    }


    
    // todo: (����) �޼��忡 �ڷ�ƾ�� ����!

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

        print("������ ���� Ŭ���ߴ�!");

        // todo: (����) ���� �ǻ� Ȯ�� �˾� ����, Yes�� ��� ����ȭ�� �ڷ�ƾ
    }

    void ShowRecord()
    {
        print("��� ����");
        // todo: (����) �ε�ȭ�� ����
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
            // todo : (����) CurrentCanvas üũ�ϴ� �Լ� �����... �׸��� �� ��ġ���� �⺻ UI ĵ���� Ȱ��ȭ��Ű��
        }


        print("���� �ִ� ĵ���� �ݱ�");
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