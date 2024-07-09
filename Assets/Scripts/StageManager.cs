using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class StageManager : MonoBehaviour
{
    /// <summary>
    /// Stage���� ���Ǵ� StageManager�Դϴ�. Stage �� ���� �ܰ�� Laoding�� ����ؼ� �� Scene���� �����Ǿ����ϴ�.
    /// </summary>
    public static StageManager instance { get; private set; }

    public List<Note> notes { get; set; } = new List<Note>(); // ��Ʈ ���� ����Ʈ

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