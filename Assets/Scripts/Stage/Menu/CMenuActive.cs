using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ������
#endregion

public class CMenuActive : MonoBehaviour
{
    public GameObject stage;

    public void OnClickReStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); // �� ��ε�
    }

    public void OnClickComebackHome()
    {
        //TODO: merge �� �κ�ȭ������ Load�ϴ� �� �߰�
        SceneManager.LoadScene(1);
    }
}
