using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 오가을
#endregion

public class CMenuActive : MonoBehaviour
{
    public GameObject stage;

    public void OnClickReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // 씬 재로드
    }

    public void OnClickComebackHome()
    {
        //TODO: merge 후 로비화면으로 Load하는 거 추가
    }
}
