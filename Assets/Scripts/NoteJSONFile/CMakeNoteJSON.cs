using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region ������
#endregion

/// <summary>
/// ��Ʈ ���� ����(JSON)�� ���� ��ũ��Ʈ �Դϴ�.
/// ���� ��Ʈ�� ���� �����ؾ� �Ѵٸ� �ش� ��ũ��Ʈ�� ���̾��Ű â�� �� ������Ʈ�� ������Ʈ�� �����ؼ�
/// �� ��Ʈ�� �����̽� ��, �� ��Ʈ�� k�� ���� �Է¹޽��ϴ�.
/// JSON ������ streamingAssets ������ �����˴ϴ�.
/// </summary>

public class CMakeNoteJSON : MonoBehaviour
{
    // For Note Check
    private List<Note> noteCheck = new List<Note>();
    private bool isEnd = false;

    private float srtNote;
    private float endNote;

    public AudioSource music;

    void Start()
    {
        music.Play();
    }

    void Update()
    {
        CheckTime();
        WriteJSON();

    }

    void CheckTime()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            srtNote = music.time;
            print($"Long Note Start: {srtNote}");
        }
        else if(Input.GetKeyUp(KeyCode.K))
        {
            endNote = music.time;
            print($"Long Note End: {endNote}");
            noteCheck.Add(new Note(1, srtNote, endNote));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            srtNote = music.time;
            print($"Short Note: {srtNote}");
            noteCheck.Add(new Note(0, srtNote, srtNote));
        }
    }

    void WriteJSON()
    {
        if(!isEnd && !music.isPlaying)
        {
            isEnd = true;

            // To JSON
            string path = $"{Application.streamingAssetsPath}/NoteData.json";

            string json = JsonConvert.SerializeObject(noteCheck);
            File.WriteAllText(path, json);

            print("END!");
        }
    }

}