using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CASSetActive : CLazerSetActive
{
    protected override void CheckNoteScore(float curMusicTime, float endTime, Vector3 Pos)
    {
        if (Mathf.Abs(Pos.y - checkZone) <= 0.6f)
        {
            disApr.ShowSCParticle(gameObject.transform.position, 0);

            StageManager.instance.score += 100;
            StageManager.instance.perfectCnt++;

            StageManager.instance.combo++;

            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else if (Mathf.Abs(Pos.y - checkZone) <= 1.2f)
        {
            disApr.ShowSCParticle(gameObject.transform.position, 1);

            StageManager.instance.score += 50;
            StageManager.instance.goodCnt++;

            StageManager.instance.combo++;

            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else
        {
            disApr.ShowWRParticle(gameObject.transform.position);

            StageManager.instance.wrCnt++;

            if (StageManager.instance.maxCombo < StageManager.instance.combo)
            {
                StageManager.instance.maxCombo = StageManager.instance.combo;
            }
            StageManager.instance.combo = 0;
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        }
    }

    protected override IEnumerator WaitUntilCondition()
    {
        if (isLong)// 롱노트 판정
        {
            // 롱노트에서 몇 번의 판정을 해야되는지 구하는 변수 ((노트 끝 - 노트 시작) * bpm / 60)
            float betweenSrtEndCnt = (((StageManager.instance.notes[noteIdx].endTime -
                StageManager.instance.notes[noteIdx].srtTime) * StageManager.instance.bpm) / 60);

            // 첫 번째 입력 판정
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            Mathf.Abs(gameObject.transform.position.y - checkZone) <= 2f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].srtTime, gameObject.transform.position);

            // 중간 노트들 점수(콤보) 추가하는 과정
            for (int i = 0; i < (int)betweenSrtEndCnt; i++)
            {
                // TODO: 밑에 wait unitl에 조건 안 걸리는 거 아닌지 확인 필요
                if (!Input.GetKey(KeyCode.Space))
                {
                    break;
                }

                if (Input.GetKey(KeyCode.Space) && StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime + (i * perSecBPM))
                {
                    StageManager.instance.combo++;
                    StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
                    print($"Long Perfect! combo: {StageManager.instance.combo}");
                    disApr.ShowSCParticle(gameObject.transform.position, 0);
                }
            }


            // 마지막 롱노트 입력 판정
            yield return new WaitUntil(() => (
           StageManager.instance.inputNoteIdx == noteIdx &&
           Input.GetKeyUp(KeyCode.Space)
           ));

            base.CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime, gameObject.transform.position);
        }
        else if (!isLong) // 숏, 더블 노트 판정
        {
            // 현재 노트 인덱스가 입력받아야할 노트인지
            // 스페이스 바 입력 여부
            // 노트가 생성되고 n초가 지났는지 체크 후 실행
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            Mathf.Abs(gameObject.transform.position.y - checkZone) <= 2f
            ));

            print($"Success! noteIdx: {noteIdx}");

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime, gameObject.transform.position);
        }

        StageManager.instance.inputNoteIdx++;

        gameObject.SetActive(false);
    }
}
