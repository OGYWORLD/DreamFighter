using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// �������� �����ϴ� ��ũ��Ʈ�Դϴ�.
/// ����Ʈ�� �ճ�Ʈ�� �����Ͽ� pool�� �����߽��ϴ�.
/// ���� ��ġ���� �÷��̾��� ��ġ(ī�޶��� ��ġ)���� 2�� �ɸ��Ƿ�
/// notes ����Ʈ�� �ð����� GameManager.instance.noteMoveSpeed�� ���� Ȱ��ȭ �� �� ī�޶� ������ �̵��մϴ�.
/// </summary>
public class CShowLazer : MonoBehaviour
{
    public enum NoteCategory
    {
        ShortNote,
        LongNote,
        DoubleNote
    }

    public CDisAprNote disApr; // ��Ʈ �Ҹ� �� �̺�Ʈ �߻� ��ũ��Ʈ

    // ������Ʈ Ǯ��
    public GameObject shortNotePrefab; // �� ��Ʈ ������
    public GameObject longNotePrefab; // �� ��Ʈ ������
    public GameObject doubleNotePrefab; // ���� ��Ʈ ������

    // ����Ʈ�� �����ϴ� position�� ������ 3���� �����Ʈ�� 2���� ���� �ڸ��� ��µǾ�� �ϹǷ�
    // (����Ʈ �ε��� + (�ճ�Ʈ �ε��� / 2)) % position�� ����(3�ڸ�)���� �ڸ��� �������ֱ� ����
    // ����Ʈ�� �ճ�Ʈ/2 �� Ǯ ũ��� 3�� ����� �ǵ��� �Ѵ�.
    protected int shortNoteNum = 9; // �� ��Ʈ Ǯ ũ��
    protected int longNoteNum = 10; // �� ��Ʈ Ǯ ũ��
    protected int doubleNoteNum = 12; // ���� ��Ʈ Ǯ ũ��

    protected List<GameObject> shortPool = new List<GameObject>(); // �� ��Ʈ Ǯ
    protected List<GameObject> longPool = new List<GameObject>(); // �� ��Ʈ Ǯ
    protected List<GameObject> doublePool = new List<GameObject>(); // ���� ��Ʈ Ǯ

    protected int shortIdx; // �� ��Ʈ Ǯ �ε���
    protected int longIdx; // �� ��Ʈ Ǯ �ε���
    protected int doubleIdx; // ���� ��Ʈ Ǯ �ε���

    protected int noteIdx; // ��Ʈ ����Ʈ �ε���

    protected CLazerSetActive lazerSet; // ��Ʈ ������ ���� �ε���

    /// <summary>
    /// �ν����� â���� ������ ��������� ������ ������Ʈ�� ��ġ�� �޽��ϴ�.
    /// </summary>
    public List<Transform> shortNoteTrans = new List<Transform>(); // ��, ���� ��Ʈ ���� ��ġ
    public Transform longNoteTrans; // �� ��Ʈ ���� ��ġ

    protected virtual void Start()
    {
        // Ǯ ����
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
        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for(int i = 0; i < shortNoteNum; i++)
        {
            GameObject obj = Instantiate(shortNotePrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            shortPool.Add(obj);
        }

        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < longNoteNum; i++)
        {
            GameObject obj = Instantiate(longNotePrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            longPool.Add(obj);
        }

        // ���� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
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
        // ��Ʈ �ð� ���� StageManager.instance.noteMoveSpeed�� ���� ��Ʈ�� �����Ѵ�.
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
