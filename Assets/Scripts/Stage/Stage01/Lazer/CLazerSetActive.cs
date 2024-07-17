using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region ������
#endregion

/// <summary>
/// ������ Ȱ��ȭ �� �̵� �ð� ���� ��Ȱ��ȭ �ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CLazerSetActive : MonoBehaviour
{
    public int noteIdx { get; set; } = 0;
    public bool isLong { get; set; }

    protected float perSecBPM;

    public CDisAprNote disApr;

    private void Start()
    {
        perSecBPM = StageManager.instance.bpm / 60f;
    }

    private void OnEnable()
    {
        StartCoroutine(WaitUntilCondition()); // �÷��̾�� ���� �����̽��ٸ� �Է¹����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
        StartCoroutine(LazerSetHide()); // ���� �ð����� ����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
    }

    protected void CheckNoteScore(float curMusicTime, float endTime)
    {
        if (Mathf.Abs(curMusicTime - endTime) < 0.2f)
        {
            disApr.ShowSCParticle(gameObject.transform.position, 0);

            StageManager.instance.score += 100;
            StageManager.instance.perfectCnt++;

            StageManager.instance.combo++;

            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else if (Mathf.Abs(curMusicTime - endTime) < 0.3f)
        {
            disApr.ShowSCParticle(gameObject.transform.position, 1);

            StageManager.instance.score += 50;
            StageManager.instance.goodCnt++;

            StageManager.instance.combo++;

            StageManager.instance.yesNoBar.value += StageManager.instance.mainMusic.clip.length * 0.0001f;
        }
        else if(Mathf.Abs(curMusicTime - endTime) <= 1f)
        {
            disApr.ShowWRParticle(gameObject.transform.position);

            StageManager.instance.wrCnt++;

            print($"Early Miss! noteIdx: {noteIdx}");
            StageManager.instance.combo = 0;
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        }
    }

    protected IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(StageManager.instance.noteMoveSpeed + (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime));
        disApr.ShowWRParticle(gameObject.transform.position);

        print($"Late Miss! noteIdx: {noteIdx}");

        StageManager.instance.wrCnt++;
        StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        StageManager.instance.combo = 0;
        StageManager.instance.inputNoteIdx++;

        gameObject.SetActive(false);
    }

    protected IEnumerator WaitUntilCondition()
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
            StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - 1f
            ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].srtTime);

            // �߰� ��Ʈ�� ����(�޺�) �߰��ϴ� ����
            for(int i = 0; i < (int)betweenSrtEndCnt; i++)
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
                }
            }


            // ������ �ճ�Ʈ �Է� ����
            yield return new WaitUntil(() => (
           StageManager.instance.inputNoteIdx == noteIdx &&
           Input.GetKeyUp(KeyCode.Space)
           ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime);
        }
        else if(!isLong) // ��, ���� ��Ʈ ����
        {
            // ���� ��Ʈ �ε����� �Է¹޾ƾ��� ��Ʈ����
            // �����̽� �� �Է� ����
            // ��Ʈ�� �����ǰ� n�ʰ� �������� üũ �� ����
            yield return new WaitUntil(() => (
            StageManager.instance.inputNoteIdx == noteIdx &&
            Input.GetKeyDown(KeyCode.Space) &&
            StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - 1f
            ));

            print($"Success! noteIdx: {noteIdx}");

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime);
        }

        StageManager.instance.inputNoteIdx++;

        gameObject.SetActive(false);
    }
}
