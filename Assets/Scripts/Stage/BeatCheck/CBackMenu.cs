using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ������
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

        // ���θ޴� �̵�
        SceneManager.LoadScene(1);
    }
}
