using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

public class StageManager : MonoBehaviour
{
    /// <summary>
    /// Stage���� ���Ǵ� StageManager�Դϴ�. Stage �� ���� �ܰ�� Laoding�� ����ؼ� �� Scene���� �����Ǿ����ϴ�.
    /// </summary>
    public static StageManager instance { get; private set; } // �̱���

    public AudioSource mainMusic; // �������� �뷡

    public float bpm; // bpm

    public List<Note> notes { get; set; } = new List<Note>(); // ��Ʈ ���� ����Ʈ

    public float noteMoveSpeed { get; set; } = 4f; // ��Ʈ �̵� �ӵ�

    public float betweenDis { get; set; } = 58f; // ������ ���� ��ġ�� ī�޶� ������ �Ÿ�

    public float noteSize { get; set; } = 0f; // ��Ʈ ������, �ճ�Ʈ ����� ���� ����

    public int inputNoteIdx { get; set; } = 0; // �Է��� ��Ʈ�� �ε���

    public int combo { get; set; } = 0; // �޺�

    public Slider yesNoBar; // yesNoBar ��� ��������

    public int score { get; set; } = 0; // ���ھ�

    public int perfectCnt { get; set; } = 0; // ����Ʈ ����
    public int goodCnt { get; set; } = 0; // �� ����
    public int wrCnt { get; set; } = 0; // Ʋ�� ����

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}

[Serializable]
public class Note
{
    public int noteCategory; // 0: short, 1: long
    public float srtTime;
    public float endTime;

    public Note(int c, float s, float e)
    {
        noteCategory = c;
        srtTime = s;
        endTime = e;
    }
}