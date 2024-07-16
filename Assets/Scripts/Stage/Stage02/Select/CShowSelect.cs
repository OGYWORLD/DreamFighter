using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CShowSelect : CShowLazer
{
    protected override void Start()
    {
        // 풀 생성
        MakePool();
    }

    private void OnEnable()
    {
        noteIdx = StageManager.instance.inputNoteIdx;
    }

    private void Update()
    {
        SetDistance();
        RespawnLazer();
    }

    protected override void SetDistance()
    {
        StageManager.instance.noteSize = StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime;
        StageManager.instance.betweenDis = 4f - (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime);
    }
}
