using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 레이저와 함께 출력되는 결과 이미지를 활성화 시키는 스크립트 입니다.
/// </summary>

public class CResultPrint : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetHide());
    }

    IEnumerator SetHide()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
