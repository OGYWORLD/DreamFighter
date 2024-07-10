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

    public AudioSource mainMusic;

    private float speed = 10f; // ������ �̵� �ӵ�

    // ������Ʈ Ǯ��
    public GameObject shortNotePrefab; // �� ��Ʈ ������
    public GameObject longNotePrefab; // �� ��Ʈ ������
    public GameObject doubleNotePrefab; // ���� ��Ʈ ������

    private int shortNoteNum = 6; // �� ��Ʈ Ǯ ũ��
    private int longNoteNum = 3; // �� ��Ʈ Ǯ ũ��
    private int doubleNoteNum = 8; // ���� ��Ʈ Ǯ ũ��

    private List<GameObject> shortPool = new List<GameObject>(); // �� ��Ʈ Ǯ
    private List<GameObject> longPool = new List<GameObject>(); // �� ��Ʈ Ǯ
    private List<GameObject> doublePool = new List<GameObject>(); // ���� ��Ʈ Ǯ

    private int shorIdx; // �� ��Ʈ Ǯ �ε���
    private int longIdx; // �� ��Ʈ Ǯ �ε���
    private int doubleIdx; // ���� ��Ʈ Ǯ �ε���

    private int noteIdx; // ��Ʈ ����Ʈ �ε���

    /// <summary>
    /// �ν����� â���� ������ ��������� ������ ������Ʈ�� ��ġ�� �޽��ϴ�.
    /// </summary>
    public List<Transform> shortNoteTrans = new List<Transform>(); // �� ��Ʈ ���� ��ġ
    public Transform longNoteTrans; // �� ��Ʈ ���� ��ġ

    private void Start()
    {
        // Ǯ ����
        MakePool();

        mainMusic.Play();
    }

    private void Update()
    {
        RespawnLazer();
    }

    void MakePool()
    {
        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for(int i = 0; i < shortNoteNum; i++)
        {
            GameObject obj = Instantiate(shortNotePrefab, shortNoteTrans[i % shortNoteTrans.Count].position, Quaternion.identity);
            obj.SetActive(false);
            shortPool.Add(obj);
        }

        // �� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < longNoteNum; i++)
        {
            GameObject obj = Instantiate(longNotePrefab, longNoteTrans.position, Quaternion.identity);
            obj.SetActive(false);
            longPool.Add(obj);
        }

        // ���� ��Ʈ ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < doubleNoteNum; i++)
        {
            GameObject obj = Instantiate(doubleNotePrefab, longNoteTrans.position, Quaternion.identity);
            obj.SetActive(false);
            doublePool.Add(obj);
        }
    }

    void RespawnLazer()
    {
        // ��Ʈ �ð� ���� StageManager.instance.noteMoveSpeed�� ���� �������� �����Ѵ�.
        if (mainMusic.time >= StageManager.instance.notes[noteIdx].srtTime - StageManager.instance.noteMoveSpeed)
        {
            switch (StageManager.instance.notes[noteIdx].noteCategory)
            {
                case (int)NoteCategory.ShortNote:

                    shortPool[shorIdx].transform.position = shortNoteTrans[shorIdx % shortNoteTrans.Count].position;
                    shortPool[shorIdx].SetActive(true);
                    shorIdx++;

                    if (shorIdx == shortPool.Count)
                    {
                        shorIdx = 0;
                    }

                    noteIdx++;
                    break;

                case (int)NoteCategory.LongNote:

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

                    doublePool[doubleIdx].transform.position = longNoteTrans.position;
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
