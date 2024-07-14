using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 정확한 노트 입력 시, 활성화되는 파티클에 부착된 스크립트 입니다.
/// </summary>
public class CShowParicle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ShowParticle());
    }

    IEnumerator ShowParticle()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
