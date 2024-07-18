using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CShowSelect : CShowLazer
{
    protected override void Start()
    {
        noteIdx = StageManager.instance.inputNoteIdx;
        StageManager.instance.betweenDis = 20f;

        // 풀 생성
        MakePool();
    }

    protected sealed override void MakePool()
    {
        // 숏 노트 오브젝트 풀 초기화
        for (int i = 0; i < shortNoteNum; i++)
        {
            GameObject obj = Instantiate(shortNotePrefab, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
            obj.SetActive(false);
            shortPool.Add(obj);
        }

        // 롱 노트 오브젝트 풀 초기화
        for (int i = 0; i < longNoteNum; i++)
        {
            GameObject obj = Instantiate(longNotePrefab, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
            obj.SetActive(false);
            longPool.Add(obj);
        }

        // 더블 노트 오브젝트 풀 초기화
        for (int i = 0; i < doubleNoteNum; i++)
        {
            GameObject obj = Instantiate(doubleNotePrefab, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
            obj.SetActive(false);
            doublePool.Add(obj);
        }
    }

    protected sealed override void SetDistance()
    {
        StageManager.instance.betweenDis = 20f 
            - ((StageManager.instance.noteRespawnTime / 20f) *
            (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime));
    }

}
