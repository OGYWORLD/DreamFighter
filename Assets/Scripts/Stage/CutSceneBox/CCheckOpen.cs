using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CCheckOpen : MonoBehaviour
{
    public GameObject[] cutScenes;

    private void Start()
    {
        for(int i = 0; i < cutScenes.Length; i++)
        {
            if(GameManager.instance.isCutSceneOpen[i])
            {
                cutScenes[i].SetActive(true);
            }
            else
            {
                cutScenes[i].SetActive(false);
            }
        }
    }
}
