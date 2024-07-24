using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CShowASNote : CShowLazer
{
    protected override void Start()
    {
        Time.timeScale = 1f;

        noteIdx = StageManager.instance.inputNoteIdx;
        StageManager.instance.betweenDis = 58f;

        // Ǯ ����
        MakePool();
    }

    protected sealed override void SetDistance()
    {
        StageManager.instance.betweenDis = 58f
            - ((StageManager.instance.noteRespawnTime / 58f) *
            (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime));
    }
}
