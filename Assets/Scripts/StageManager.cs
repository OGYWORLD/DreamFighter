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
    public static StageManager instance { get; private set; } // 싱글톤

    public AudioSource mainMusic; // 스테이지 노래

    public List<Note> notes { get; set; } = new List<Note>(); // 노트 정보 리스트

    public float noteMoveSpeed { get; set; } = 4f; // 노트 이동 속도

    public float betweenDis {get; set;} = 58f; // 레이저 생성 위치와 카메라 사이의 거리

    public float noteSize { get; set; } = 0f; // 노트 사이즈, 롱노트 사이즈를 위해 사용됨

    public int inputNoteIdx { get; set; } = 0; // 입력할 노트의 인덱스

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