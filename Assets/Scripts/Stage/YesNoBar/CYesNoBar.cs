using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 오가을
#endregion

/// <summary>
/// 화면 상단에 등장하는 YesNo 게이지 바를 제어하는 스크립트 입니다.
/// </summary>
public class CYesNoBar : MonoBehaviour
{
    private void Start()
    {
        StageManager.instance.yesNoBar.value = 1f;

        StartCoroutine(UpdateBar());
    }

    // 게이지바는 음악 길이 * 0.00001f씩 감소
    IEnumerator UpdateBar()
    {
        yield return new WaitUntil(() => (StageManager.instance.mainMusic.isPlaying 
        && StageManager.instance.mainMusic.time >= StageManager.instance.notes[0].srtTime - 1f));

        while(StageManager.instance.mainMusic.isPlaying)
        {
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.00001f;

            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }
}
