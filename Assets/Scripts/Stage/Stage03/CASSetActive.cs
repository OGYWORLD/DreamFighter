using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
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
        if (isLong)// �ճ�Ʈ ����
        {
            // �ճ�Ʈ���� �� ���� ������ �ؾߵǴ��� ���ϴ� ���� ((��Ʈ �� - ��Ʈ ����) * bpm / 60)
            float betweenSrtEndCnt = (((StageManager.instance.notes[noteIdx].endTime -
                StageManager.instance.notes[noteIdx].srtTime) * StageManager.instance.bpm) / 60);

            // ù ��° �Է� ����
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            Mathf.Abs(gameObject.transform.position.y - checkZone) <= 2f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].srtTime, gameObject.transform.position);

            // �߰� ��Ʈ�� ����(�޺�) �߰��ϴ� ����
            for (int i = 0; i < (int)betweenSrtEndCnt; i++)
            {
                // TODO: �ؿ� wait unitl�� ���� �� �ɸ��� �� �ƴ��� Ȯ�� �ʿ�
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


            // ������ �ճ�Ʈ �Է� ����
            yield return new WaitUntil(() => (
           StageManager.instance.inputNoteIdx == noteIdx &&
           Input.GetKeyUp(KeyCode.Space)
           ));

            base.CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime, gameObject.transform.position);
        }
        else if (!isLong) // ��, ���� ��Ʈ ����
        {
            // ���� ��Ʈ �ε����� �Է¹޾ƾ��� ��Ʈ����
            // �����̽� �� �Է� ����
            // ��Ʈ�� �����ǰ� n�ʰ� �������� üũ �� ����
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
