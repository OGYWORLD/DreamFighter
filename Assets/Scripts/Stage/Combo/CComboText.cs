using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#region ������
#endregion

/// <summary>
/// �޺� �ؽ�Ʈ�� ������Ʈ �ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>

public class CComboText : MonoBehaviour
{
    public TextMeshProUGUI comboText;

    private void Update()
    {
        comboText.text = "" + StageManager.instance.combo;   
    }
}
