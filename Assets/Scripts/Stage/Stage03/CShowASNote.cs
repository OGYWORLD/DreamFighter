using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CShowASNote : CShowLazer
{
    protected override void Start()
    {
        noteIdx = StageManager.instance.inputNoteIdx;
        StageManager.instance.betweenDis = 10f;

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

    private void Update()
    {
        SetDistance();
        RespawnLazer();
    }

    protected sealed override void SetDistance()
    {
        StageManager.instance.betweenDis = 10f
            - ((StageManager.instance.noteRespawnTime / 10f) *
            (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime));
    }

    protected override void RespawnLazer()
    {
        // 노트 시간 보다 StageManager.instance.noteMoveSpeed초 전에 노트를 생성한다.
        if (!StageManager.instance.isCutScene
            && StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - StageManager.instance.noteRespawnTime)
        {
            switch (StageManager.instance.notes[noteIdx].noteCategory)
            {
                case (int)NoteCategory.ShortNote:
                    lazerSet = shortPool[shortIdx].GetComponent<CLazerSetActive>();
                    lazerSet.noteIdx = noteIdx;
                    lazerSet.isLong = false;
                    lazerSet.checkZone = checkZone.transform.position.x;

                    lazerSet.disApr = disApr;

                    shortPool[shortIdx].transform.position = shortNoteTrans[(shortIdx + (doubleIdx / 2)) % shortNoteTrans.Count].position;
                    shortPool[shortIdx].SetActive(true);
                    shortIdx++;

                    if (shortIdx == shortPool.Count)
                    {
                        shortIdx = 0;
                    }

                    noteIdx++;
                    break;

                case (int)NoteCategory.LongNote:
                    lazerSet = longPool[longIdx].GetComponent<CLazerSetActive>();
                    lazerSet.noteIdx = noteIdx;
                    lazerSet.isLong = true;
                    lazerSet.checkZone = checkZone.transform.position.x;

                    lazerSet.disApr = disApr;

                    longPool[longIdx].transform.localScale = new Vector3(
                        longPool[longIdx].transform.localScale.x,
                        (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime) * (StageManager.instance.betweenDis / StageManager.instance.noteRespawnTime),
                        longPool[longIdx].transform.localScale.z
                        );

                    longPool[longIdx].transform.position = longNoteTrans.position;
                    longPool[longIdx].SetActive(true);
                    longIdx++;

                    if (longIdx == longPool.Count)
                    {
                        longIdx = 0;
                    }

                    noteIdx++;
                    break;

                case (int)NoteCategory.DoubleNote:

                    lazerSet = doublePool[doubleIdx].GetComponent<CLazerSetActive>();
                    lazerSet.noteIdx = noteIdx;
                    lazerSet.isLong = false;
                    lazerSet.checkZone = checkZone.transform.position.x;

                    lazerSet.disApr = disApr;

                    doublePool[doubleIdx].transform.position = shortNoteTrans[(shortIdx + (doubleIdx / 2)) % shortNoteTrans.Count].position;
                    doublePool[doubleIdx].SetActive(true);
                    doubleIdx++;

                    if (doubleIdx == doublePool.Count)
                    {
                        doubleIdx = 0;
                    }

                    noteIdx++;
                    break;
            }
        }

    }
}
