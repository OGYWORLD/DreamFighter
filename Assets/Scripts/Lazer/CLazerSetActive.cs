using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 오가을
#endregion

/// <summary>
/// 레이저 활성화 후 이동 시간 이후 비활성화 하는 스크립트 입니다.
/// </summary>
public class CLazerSetActive : MonoBehaviour
{
    public int noteIdx { get; set; }
    public bool isLong { get; set; }

    private float perSecBPM;

    public Slider yesNoBar;

    private void Start()
    {
        perSecBPM = StageManager.instance.bpm / 60f;
    }

    private void OnEnable()
    {
        StartCoroutine(WaitUntilCondition()); // 플레이어로 부터 스페이스바를 입력받으면 레이저를 비활성화 시킵니다.
        StartCoroutine(LazerSetHide()); // 판정 시간에서 벗어나면 레이저를 비활성화 시킵니다.
    }

    void CheckNoteScore(float curMusicTime, float endTime)
    {
        if (Mathf.Abs(curMusicTime - endTime) < 0.2f)
        {
            StageManager.instance.combo++;
            print($"{StageManager.instance.inputNoteIdx} Perfect! combo: {StageManager.instance.combo}");
            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else if (Mathf.Abs(curMusicTime - endTime) < 0.3f)
        {
            StageManager.instance.combo++;
            print($"{StageManager.instance.inputNoteIdx} Good! combo: {StageManager.instance.combo}");
            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else if(Mathf.Abs(curMusicTime - endTime) <= 1f)
        {
            print($"{StageManager.instance.inputNoteIdx} Early Miss!");
            StageManager.instance.combo = 0;
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        }
    }

    IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(StageManager.instance.noteMoveSpeed + StageManager.instance.noteSize);
        print($"{StageManager.instance.inputNoteIdx} Late Miss!");
        StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        StageManager.instance.combo = 0;
        StageManager.instance.inputNoteIdx++;
        gameObject.SetActive(false);
    }

    IEnumerator WaitUntilCondition()
    {
        if(isLong)// 롱노트 판정
        {
            // 롱노트에서 몇 번의 판정을 해야되는지 구하는 변수 ((노트 끝 - 노트 시작) * bpm / 60)
            float betweenSrtEndCnt = (((StageManager.instance.notes[noteIdx].endTime -
                StageManager.instance.notes[noteIdx].srtTime) * StageManager.instance.bpm) / 60);

            // 첫 번째 입력 판정
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - 1f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].srtTime);

            // 중간 노트들 점수(콤보) 추가하는 과정 필요
            for(int i = 0; i < (int)betweenSrtEndCnt; i++)
            {
                if (Input.GetKey(KeyCode.Space) && StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime + (i * perSecBPM))
                {
                    StageManager.instance.combo++;
                    StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
                    print($"Long Perfect! combo: {StageManager.instance.combo}");
                }
            }


            // 마지막 롱노트 입력 판정
            yield return new WaitUntil(() => (
           StageManager.instance.inputNoteIdx == noteIdx &&
           Input.GetKeyUp(KeyCode.Space) &&
           StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].endTime
           ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime);
        }
        else if(!isLong) // 숏, 더블 노트 판정
        {
            // 현재 노트 인덱스가 입력받아야할 노트인지
            // 스페이스 바 입력 여부
            // 노트가 생성되고 3초가 지났는지 체크 후 실행
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - 1f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime);
        }

        StageManager.instance.inputNoteIdx++;
        gameObject.SetActive(false);
    }
}
