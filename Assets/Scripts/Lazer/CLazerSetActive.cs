using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

/// <summary>
/// ������ Ȱ��ȭ �� �̵� �ð� ���� ��Ȱ��ȭ �ϴ� ��ũ��Ʈ �Դϴ�.
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
        StartCoroutine(WaitUntilCondition()); // �÷��̾�� ���� �����̽��ٸ� �Է¹����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
        StartCoroutine(LazerSetHide()); // ���� �ð����� ����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
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
        if(isLong)// �ճ�Ʈ ����
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

            // �߰� ��Ʈ�� ����(�޺�) �߰��ϴ� ���� �ʿ�
            for(int i = 0; i < (int)betweenSrtEndCnt; i++)
            {
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
           Input.GetKeyUp(KeyCode.Space) &&
           StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].endTime
           ));

            CheckNoteScore(StageManager.instance.mainMusic.time, StageManager.instance.notes[noteIdx].endTime);
        }
        else if(!isLong) // ��, ���� ��Ʈ ����
        {
            // ���� ��Ʈ �ε����� �Է¹޾ƾ��� ��Ʈ����
            // �����̽� �� �Է� ����
            // ��Ʈ�� �����ǰ� 3�ʰ� �������� üũ �� ����
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
