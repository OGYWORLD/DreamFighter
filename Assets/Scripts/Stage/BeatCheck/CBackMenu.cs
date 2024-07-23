using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 오가을
#endregion

public class CBackMenu : MonoBehaviour
{
    public void NoButton()
    {
        Time.timeScale = 1f;
        MenuManager.instance.isOpenMenu = false;
        gameObject.SetActive(false);
    }

    public void YesButton()
    {
        Time.timeScale = 1f;

        // 메인메뉴 이동
        SceneManager.LoadScene(1);
    }
}
