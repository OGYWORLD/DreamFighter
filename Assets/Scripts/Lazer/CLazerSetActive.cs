using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// ������ Ȱ��ȭ �� �̵� �ð� ���� ��Ȱ��ȭ �ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CLazerSetActive : MonoBehaviour
{
    public int noteIdx { get; set; }
    public bool isLong { get; set; }

    private float noteDisaprPadding = 0.3f;

    private void OnEnable()
    {
       StartCoroutine(LazerSetHide()); // ���� �������� ����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
       StartCoroutine(WaitUntilCondition()); // �÷��̾�� ���� �����̽��ٸ� �Է¹����� �������� ��Ȱ��ȭ ��ŵ�ϴ�.
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
            // �ճ�Ʈ ����
        }
        else if(!isLong)
        {
            // ���� ��Ʈ �ε����� �Է¹޾ƾ��� ��Ʈ����
            // �����̽� �� �Է� ����
            // ��Ʈ�� �����ǰ� 3�ʰ� �������� üũ �� ����
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
