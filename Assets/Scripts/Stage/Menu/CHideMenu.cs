using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class CHideMenu : MonoBehaviour
{
    public GameObject menuInfo;

    private void Update()
    {
        if(StageManager.instance.isPlayingCutScene)
        {
            menuInfo.SetActive(false);
        }
        else
        {
            menuInfo.SetActive(true);
        }
    }
}
