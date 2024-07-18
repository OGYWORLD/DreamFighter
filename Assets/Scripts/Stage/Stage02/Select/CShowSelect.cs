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
        StageManager.instance.betweenDis = 20f;

        // Ǯ ����
        MakePool();
    }

    protected sealed override void MakePool()
    {
        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < shortNoteNum; i++)
        {
            GameObject obj = Instantiate(shortNotePrefab, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
            obj.SetActive(false);
            shortPool.Add(obj);
        }

        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < longNoteNum; i++)
        {
            GameObject obj = Instantiate(longNotePrefab, Vector3.zero, Quaternion.Euler(0f, 180f, 0f));
            obj.SetActive(false);
            longPool.Add(obj);
        }

        // ���� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
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
