using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region 오가을
#endregion

/// <summary>
/// 노트 파일 생성(JSON)을 위한 스크립트 입니다.
/// 만약 노트를 새로 생성해야 한다면 해당 스크립트를 하이어라키 창에 빈 오브젝트의 컴포넌트로 생성해서
/// 숏 노트는 스페이스 바, 롱 노트는 k를 통해 입력받습니다.
/// JSON 파일은 streamingAssets 폴더에 생성됩니다.
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