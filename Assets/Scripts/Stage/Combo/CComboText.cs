using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#region 오가을
#endregion

/// <summary>
/// 콤보 텍스트를 업데이트 하는 스크립트 입니다.
/// </summary>

public class CComboText : MonoBehaviour
{
    public TextMeshProUGUI comboText;

    private void Update()
    {
        comboText.text = "" + StageManager.instance.combo;   
    }
}
