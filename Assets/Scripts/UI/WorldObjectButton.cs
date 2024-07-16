using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region ������
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
    /// �ν����͸� ���� List�� ����� ������ Dictionary�� �Ű� ��� �޼���
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
                Debug.LogWarning($"������ �̸� ����: {info.name}");
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
    /// ���콺 ���� ��ư�� ������ ��쿡�� ��� ������Ʈ�� Ŭ���Ǿ����� �Ǻ��ϴ� ��ȸ�� �ڷ�ƾ�� �����Ű�� �ڷ�ƾ
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
    /// <seealso cref="Dictionary{TKey, TValue}<"/>�� key�� ����ϱ� ���� �浹 ����� �̸��� �Ǻ��ϴ� �ڷ�ƾ  <br/>
    /// ���� �ڵ����� ���� ������ �����ϴ� �ڷ�ƾ ����
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
    /// ��ư���� Ȱ��Ǵ� 3D ������Ʈ �� ��� ���� ���ȴ����� ���� ���� �ٸ� �޼��� ����
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


    
    // �޼��忡 �ڷ�ƾ�� ����~

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
        print("������ ���� Ŭ���ߴ�!");
        // todo: �� ��������. �� �� �Ǹ� �׳� 3D��ư �ϳ��ϳ� ��ũ��Ʈ ����� ����...

        // todo: (����) ���� �ǻ� Ȯ�� �˾� ����, Yes�� ��� ����ȭ�� �ڷ�ƾ
    }

    void ShowStart()
    { 
        // todo: (����) �ε�ȭ�� ����
    }


    // �̰� ��ü���� �³���... ���� ������⸸ �ϴ� ��ũ��Ʈ.



    // �̰� �� ������...
    private void OnMouseEnter()
    {
        Debug.Log("��ư ������ ���콺 ���Դ�!");
    }

    private void OnMouseExit()
    {
        Debug.Log("���콺 ġ��!");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("ó�� Ŭ���ߴ� ������ Ŭ�� ����!");
    }
}
