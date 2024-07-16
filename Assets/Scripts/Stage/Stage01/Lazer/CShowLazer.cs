using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 레이저를 생성하는 스크립트입니다.
/// 숏노트와 롱노트를 구분하여 pool을 구현했습니다.
/// 생성 위치에서 플레이어의 위치(카메라의 위치)까지 2초 걸리므로
/// notes 리스트의 시간보다 GameManager.instance.noteMoveSpeed초 먼저 활성화 한 후 카메라 쪽으로 이동합니다.
/// </summary>
public class CShowLazer : MonoBehaviour
{
    public enum NoteCategory
    {
        ShortNote,
        LongNote,
        DoubleNote
    }

    public CDisAprNote disApr; // 노트 소멸 시 이벤트 발생 스크립트

    // 오브젝트 풀링
    public GameObject shortNotePrefab; // 숏 노트 프리팹
    public GameObject longNotePrefab; // 롱 노트 프리팹
    public GameObject doubleNotePrefab; // 더블 노트 프리팹

    // 숏노트와 공유하는 position의 개수가 3개고 더블노트는 2개씩 같은 자리에 출력되어야 하므로
    // (숏노트 인덱스 + (롱노트 인덱스 / 2)) % position의 개수(3자리)으로 자리를 지정해주기 위해
    // 숏노트와 롱노트/2 의 풀 크기는 3의 배수가 되도록 한다.
    protected int shortNoteNum = 9; // 숏 노트 풀 크기
    protected int longNoteNum = 10; // 롱 노트 풀 크기
    protected int doubleNoteNum = 12; // 더블 노트 풀 크기

    protected List<GameObject> shortPool = new List<GameObject>(); // 숏 노트 풀
    protected List<GameObject> longPool = new List<GameObject>(); // 롱 노트 풀
    protected List<GameObject> doublePool = new List<GameObject>(); // 더블 노트 풀

    protected int shortIdx; // 숏 노트 풀 인덱스
    protected int longIdx; // 롱 노트 풀 인덱스
    protected int doubleIdx; // 더블 노트 풀 인덱스

    protected int noteIdx; // 노트 리스트 인덱스

    protected CLazerSetActive lazerSet; // 노트 레이저 세팅 인덱스

    /// <summary>
    /// 인스펙터 창에서 리스폰 베리어에서의 리스폰 오브젝트의 위치를 받습니다.
    /// </summary>
    public List<Transform> shortNoteTrans = new List<Transform>(); // 숏, 더블 노트 생성 위치
    public Transform longNoteTrans; // 롱 노트 생성 위치

    protected virtual void Start()
    {
        // 풀 생성
        MakePool();

        StageManager.instance.mainMusic.Play();
    }

    private void Update()
    {
        SetDistance();
        RespawnLazer();
    }

    protected virtual void MakePool()
    {
        // 숏 노트 오브젝트 풀 초기화
        for(int i = 0; i < shortNoteNum; i++)
        {
            GameObject obj = Instantiate(shortNotePrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            shortPool.Add(obj);
        }

        // 롱 노트 오브젝트 풀 초기화
        for (int i = 0; i < longNoteNum; i++)
        {
            GameObject obj = Instantiate(longNotePrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            longPool.Add(obj);
        }

        // 더블 노트 오브젝트 풀 초기화
        for (int i = 0; i < doubleNoteNum; i++)
        {
            GameObject obj = Instantiate(doubleNotePrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            doublePool.Add(obj);
        }
    }

    protected virtual void SetDistance()
    {
        StageManager.instance.betweenDis = 58f - (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime);
    }

    protected void RespawnLazer()
    {
        // 노트 시간 보다 StageManager.instance.noteMoveSpeed초 전에 노트를 생성한다.
        if (!StageManager.instance.isCutScene
            && StageManager.instance.mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - StageManager.instance.noteMoveSpeed)
        {
            switch (StageManager.instance.notes[noteIdx].noteCategory)
            {
                case (int)NoteCategory.ShortNote:
                    lazerSet = shortPool[shortIdx].GetComponent<CLazerSetActive>();
                    lazerSet.noteIdx = noteIdx;
                    lazerSet.isLong = false;

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

                    lazerSet.disApr = disApr;

                    longPool[longIdx].transform.localScale = new Vector3(
                        (StageManager.instance.notes[noteIdx].endTime - StageManager.instance.notes[noteIdx].srtTime) * (StageManager.instance.betweenDis / StageManager.instance.noteMoveSpeed),
                        longPool[longIdx].transform.localScale.y,
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
