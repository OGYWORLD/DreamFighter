using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 오가을
#endregion

/// <summary>
/// 상단의 YesNoBar에 따라 위험 아이콘과 위험 프레임을 활성화/비활성화하는 동작이 담긴 스크립트 입니다.
/// </summary>
public class CShowWarning : MonoBehaviour
{
    private float deadline = 0.4f; // 위험 프레임 활성화 값
    private float lastDeadline = 0.2f; // 위험 아이콘 활성화 값

    public GameObject warningFrame;
    public GameObject warningIcon;
    public Sprite wrongIcon; // 데드라인 이하 시, 변경될 핸들 이미지
    public Sprite rightIcon; // 데드라인 초과 시, 변경될 핸들 이미지

    public Image handle; // yesNoBar Handle

    private void Update()
    {
        ShowWarningFrame();
        ShowWarningIcon();
    }

    void ShowWarningFrame()
    {
        if(StageManager.instance.yesNoBar.value <= deadline)
        {
            handle.sprite = wrongIcon;
            warningFrame.SetActive(true);
        }
        else
        {
            handle.sprite = rightIcon;
            warningFrame.SetActive(false);
        }
    }

    void ShowWarningIcon()
    {
        if (StageManager.instance.yesNoBar.value <= lastDeadline)
        {
            warningIcon.SetActive(true);
        }
        else
        {
            warningIcon.SetActive(false);
        }
    }
}
