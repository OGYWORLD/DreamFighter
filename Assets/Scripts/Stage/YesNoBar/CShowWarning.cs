using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

/// <summary>
/// ����� YesNoBar�� ���� ���� �����ܰ� ���� �������� Ȱ��ȭ/��Ȱ��ȭ�ϴ� ������ ��� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CShowWarning : MonoBehaviour
{
    private float deadline = 0.4f; // ���� ������ Ȱ��ȭ ��
    private float lastDeadline = 0.2f; // ���� ������ Ȱ��ȭ ��

    public GameObject warningFrame;
    public GameObject warningIcon;
    public Sprite wrongIcon; // ������� ���� ��, ����� �ڵ� �̹���
    public Sprite rightIcon; // ������� �ʰ� ��, ����� �ڵ� �̹���

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
