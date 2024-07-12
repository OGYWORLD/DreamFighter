using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 레이저 활성화 후 이동 시간 이후 비활성화 하는 스크립트 입니다.
/// </summary>
public class CLazerSetActive : MonoBehaviour
{
    public int noteIdx { get; set; }
    public bool isLong { get; set; }

    private float noteDisaprPadding = 0.3f;

    private void OnEnable()
    {
       StartCoroutine(LazerSetHide()); // 판정 범위에서 벗어나면 레이저를 비활성화 시킵니다.
       StartCoroutine(WaitUntilCondition()); // 플레이어로 부터 스페이스바를 입력받으면 레이저를 비활성화 시킵니다.
    }

    void CheckNoteScore(float curMusicTime)
    {
        if (Mathf.Abs(curMusicTime - StageManager.instance.notes[noteIdx].endTime) < 0.2f)
        {
            print("Perfect!");
        }
        else if (Mathf.Abs(curMusicTime - StageManager.instance.notes[noteIdx].endTime) < 0.3f)
        {
            print("Good!");
        }
        else if(Mathf.Abs(curMusicTime - StageManager.instance.notes[noteIdx].endTime) <= 1f)
        {
            print("Miss!");
        }
    }

    IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(StageManager.instance.noteMoveSpeed + StageManager.instance.noteSize + noteDisaprPadding);
        print("Miss!");
        StageManager.instance.inputNoteIdx++;
        gameObject.SetActive(false);
    }

    IEnumerator WaitUntilCondition()
    {
        if(isLong)
        {
            // 롱노트 판정
        }
        else if(!isLong)
        {
            // 현재 노트 인덱스가 입력받아야할 노트인지
            // 스페이스 바 입력 여부
            // 노트가 생성되고 3초가 지났는지 체크 후 실행
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - 1f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time);
        }
      
        StageManager.instance.inputNoteIdx++;
        gameObject.SetActive(false);
    }
}
