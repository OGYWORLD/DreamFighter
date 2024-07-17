using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using UnityEngine.Video;

#region 오가을
#endregion

/// <summary>
/// 스테이지에서 컷씬 전환, 컷씬에서 스테이지 전환을 하는 스크립트입니다.
/// </summary>
public class CCutScenePlayer : MonoBehaviour
{
    public AudioSource bgm; // 배경음악

    private List<CutScene> cutscene = new List<CutScene>(); // 컷씬 시작, 종료를 담은 리스트

    private int idx = 0; // 컷씬 리스트 인덱스

    public GameObject[] stage = new GameObject[3]; // 스테이지

    public CFadeOutIn fade; // 페이드 인 아웃

    private bool isPlay = false; // 컷씬 재생 여부 (실제 재생 여부와 페이드 때문에 시점이 달라서 변수로 처리)

    private void Awake()
    {
        LoadJSON();
    }

    private void LoadJSON()
    {
        string path = $"{Application.streamingAssetsPath}/CutSceneData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            cutscene = JsonConvert.DeserializeObject<List<CutScene>>(json);
        }
    }

    private void Update()
    {
        IsCutSceneCheck();
        IntoCutScene();
        IntoStage();
    }

    private void IsCutSceneCheck()
    {
        if (bgm.time >= cutscene[idx].srtTime - 7f)
        {
            StageManager.instance.isCutScene = true;
        }

        if (bgm.time >= cutscene[idx].endTime + 3f)
        {
            StageManager.instance.isCutScene = false;
            idx++;
        }
    }

    private void IntoCutScene()
    {
       if (!isPlay && bgm.time >= cutscene[StageManager.instance.curStage].srtTime - 2f)
       {
            isPlay = true;

            for(int i = StageManager.instance.inputNoteIdx; i < StageManager.instance.notes.Count; i++)
            {
                if(cutscene[idx].endTime + 3f <= StageManager.instance.notes[i].srtTime - 4f)
                {
                    StageManager.instance.inputNoteIdx = i;
                    break;
                }
            }

            fade.Fade(0, 1, 1);
        }
    }

    private void IntoStage()
    {
        if (bgm.time >= cutscene[StageManager.instance.curStage].endTime)
        {
            // 스테이지 교환
            stage[StageManager.instance.curStage].SetActive(false);
            StageManager.instance.curStage++;
            stage[StageManager.instance.curStage].SetActive(true);

            // 스테이지 전환
            fade.Fade(1, 0, 1);

            isPlay = false;
        }
    }
}

[Serializable]
public class CutScene
{
    public float srtTime { get; set; }
    public float endTime { get; set; }

    public CutScene(int s, int e)
    {
        srtTime = s;
        endTime = e;
    }
}