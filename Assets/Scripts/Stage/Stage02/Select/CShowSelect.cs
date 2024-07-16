using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CShowSelect : CShowLazer
{
    protected override void Start()
    {
        noteIdx = StageManager.instance.inputNoteIdx;

        // Ǯ ����
        MakePool();
    }

    private void OnEnable()
    {
        StageManager.instance.betweenDis = 4.841f;
    }

    private void Update()
    {
        SetDistance();
        RespawnLazer();
    }

    protected override void SetDistance()
    {
        StageManager.instance.betweenDis = 4.802f - (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime);
    }
}
