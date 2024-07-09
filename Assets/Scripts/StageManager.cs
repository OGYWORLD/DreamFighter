using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class StageManager : MonoBehaviour
{
    /// <summary>
    /// Stage에서 사용되는 StageManager입니다. Stage 내 여러 단계는 Laoding을 고려해서 한 Scene에서 구현되었습니다.
    /// </summary>
    public static StageManager instance { get; private set; }

    public List<Note> notes { get; set; } = new List<Note>(); // 노트 정보 리스트

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