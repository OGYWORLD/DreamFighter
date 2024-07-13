using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region ¿ìÀÎÇý
#endregion

//[Serializable]
//public class UIObject
//{
//    public GameObject uiObject;

//    public void FadeIn()
//    {

//    }

//    public void FadeOut()
//    {

//    }
//}

public class UIManager : Singleton<UIManager>
{
    //public GameObject TitleWorldObject;
    public Dictionary<string, GameObject> WorldUIObjects = new();

    public Canvas MainCanvas;

    public void SetActiveUI(GameObject obj, bool b)
    {
        obj.gameObject.SetActive(b);
    }

    public void SetActiveUIByName()
    {

    }

}
