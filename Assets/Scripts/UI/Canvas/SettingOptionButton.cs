using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;
using System;

#region ¿ìÀÎÇý
#endregion

[Serializable]

public class BtnNTargetPageInfo
{
    public Button btn;
    public GameObject targetPage;
}

public class SettingOptionButton : MonoBehaviour
{
    BtnNTargetPageInfo firstBtnNPage;

    public List<BtnNTargetPageInfo> BtnNTargetPageList = new();
    private Dictionary<Button, GameObject> BtnNTargetPageDic = new();

    private void Awake()
    {
        InitDictionary();
        InitPages();
    }

    void InitDictionary()
    {
        firstBtnNPage = BtnNTargetPageList[0];

        foreach(BtnNTargetPageInfo info in BtnNTargetPageList)
        {
            BtnNTargetPageDic.Add(info.btn, info.targetPage);
        }

        BtnNTargetPageList = null;
    }

    void InitPages()
    {
        CloseAllPages();
        ActivateTargetPage(firstBtnNPage.btn);
    }

    public void TargetPageToggle(Button btn)
    {
        if(!BtnNTargetPageDic[btn].gameObject.activeSelf)
        {
            ActivateTargetPage(btn);
            CloseAnotherPages(btn);
        }
        else
        {
            SetActivateTargetPage(btn, false);
        }
    }

    public void BtnOnClick(Button btn)
    {
        ActivateTargetPage(btn);
        CloseAnotherPages(btn);
    }

    void SetActivateTargetPage(Button btn, bool b)
    {
        BtnNTargetPageDic[btn].SetActive(b);
    }

    void CloseAllPages()
    {
        foreach(KeyValuePair<Button, GameObject> pair in BtnNTargetPageDic)
        {
            Button keyBtn = pair.Key;
            pair.Value.SetActive(false);
        }
    }

    void CloseAnotherPages(Button selectedBtn)
    {
        foreach(KeyValuePair<Button, GameObject> pair in BtnNTargetPageDic)
        {
            if(pair.Key != selectedBtn)
            {
                pair.Value.SetActive(false);
            }
        }
    }

    void ActivateTargetPage(Button btn)
    {
        BtnNTargetPageDic[btn].gameObject.SetActive(true);
    }
}
