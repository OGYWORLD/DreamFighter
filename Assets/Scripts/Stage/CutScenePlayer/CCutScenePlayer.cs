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

    public GameObject cutSceneCanvas; // 컷씬 캔버스
    public VideoPlayer cutScenePlayer; // 컷씬 비디오 플레이어

    private List<CutScene> cutscene = new List<CutScene>(); // 컷씬 시작, 종료를 담은 리스트

    private int idx = 0; // 컷씬 리스트 인덱스

    public GameObject[] stage = new GameObject[3]; // 스테이지

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
        if (bgm.time >= cutscene[idx].srtTime - 5f)
        {
            StageManager.instance.isCutScene = true;
        }

        if (bgm.time >= cutscene[idx].endTime + 5f)
        {
            StageManager.instance.isCutScene = false;
        }
    }

    private void IntoCutScene()
    {
       if(!cutScenePlayer.isPlaying && bgm.time >= cutscene[StageManager.instance.curStage].srtTime)
       {
            // 노래 볼륨 조절


            // 컷신 전환
            cutSceneCanvas.SetActive(true);
            cutScenePlayer.Play();

            // 노트 idx 건너뛰어줘야함
            for(int i = StageManager.instance.inputNoteIdx; i < StageManager.instance.notes.Count; i++)
            {
                if(cutscene[StageManager.instance.curStage].endTime >= StageManager.instance.notes[i].srtTime)
                {
                    StageManager.instance.inputNoteIdx = i;
                    break;
                }
            }
       }
    }

    private void IntoStage()
    {
        if (bgm.time >= cutscene[StageManager.instance.curStage].endTime)
        {
            // 스테이지 전환
            cutSceneCanvas.SetActive(false);
            cutScenePlayer.Stop();

            // 노트 인덱스 업데이트는 2번째 스테이지에서 CShowLazer를 사용하지 않고 새로 스크립트 파서
            // 풀링해줄 거기 때문에 그 스크립트에서 StageManager.instance.inputNoteIdx 값을 활성화됐을때 집어넣는 방식으로 구현할예정

            // 스테이지 교환
            stage[StageManager.instance.curStage].SetActive(false);
            StageManager.instance.curStage++;
            stage[StageManager.instance.curStage].SetActive(true);
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