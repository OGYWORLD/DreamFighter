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
    public float checkZone { get; set; }

    protected float perSecBPM;

    public CDisAprNote disApr;

    protected void Start()
    {
        perSecBPM = 60f / StageManager.instance.bpm;
    }

    protected void OnEnable()
    {
        StartCoroutine(WaitUntilCondition()); // �÷��̾�� ���� �����̽��ٸ� �Է¹����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
        StartCoroutine(LazerSetHide()); // ���� �ð����� ����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
    }

    protected virtual void CheckNoteScore(float curMusicTime, float endTime, Vector3 pos)
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
        else
        {
            if(!StageManager.instance.isGameOver)
            {
                disApr.ShowWRParticle(gameObject.transform.position);
            }

            StageManager.instance.wrCnt++;

            if (StageManager.instance.maxCombo < StageManager.instance.combo)
            {
                StageManager.instance.maxCombo = StageManager.instance.combo;
            }
            StageManager.instance.combo = 0;
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        }
    }

    protected IEnumerator LazerSetHide()
    {
        yield return new WaitForSeconds(StageManager.instance.noteRespawnTime + (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime));
        if (!StageManager.instance.isGameOver)
        {
            disApr.ShowWRParticle(gameObject.transform.position);
        }

        StageManager.instance.wrCnt++;
        StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.0005f;
        StageManager.instance.combo = 0;
        StageManager.instance.inputNoteIdx++;

        gameObject.SetActive(false);
    }

    protected virtual IEnumerator WaitUntilCondition()
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

            CheckNoteScore(StageManager.instance.mainMusic.time + GameManager.instance.beatPadding, StageManager.instance.notes[noteIdx].srtTime, gameObject.transform.position);

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
                }
            }


            // ������ �ճ�Ʈ �Է� ����
            yield return new WaitUntil(() => (
           StageManager.instance.inputNoteIdx == noteIdx &&
           Input.GetKeyUp(KeyCode.Space)
           ));

            CheckNoteScore(StageManager.instance.mainMusic.time + GameManager.instance.beatPadding, StageManager.instance.notes[noteIdx].endTime, gameObject.transform.position);
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

            CheckNoteScore(StageManager.instance.mainMusic.time + GameManager.instance.beatPadding, StageManager.instance.notes[noteIdx].endTime, gameObject.transform.position);
        }

        StageManager.instance.inputNoteIdx++;

        gameObject.SetActive(false);
    }
}
