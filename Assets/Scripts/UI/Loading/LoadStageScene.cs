using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class LoadStageScene : MonoBehaviour
{
    const string stageScene = "StageScene";

    public void OnClickLoadStageScene()
    {
        LoadSceneController.LoadScene(stageScene);
    }
}
