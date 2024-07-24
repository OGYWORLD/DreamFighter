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

    public GameObject postCamera; // 인트로 카메라

    public VideoPlayer cutscnenePlayer; // 컷씬 플레이어

    public GameObject cutSceneCanvas; // 컷씬 캔버스

    public RenderTexture renderTexture; // 비디오 플레이어 렌더러 텍스처

    public int cutsceneIdx = 0; // 컷씬 인덱스

    public GameObject totalStage; // 스테이지

    public GameObject scoreStage; // 스코어 화면

    public GameObject skipButton; // 스킵 버튼

    public GameObject GameOverObj; // 게임 오버 UI

    private float[] startPaddingTime = new float[3];

    // CutScenes
    // Post, stage01 SC, stage01 FL, stage02 SC, stage02 FL, Ending, Gameover
    public VideoClip[] cutScenes;

    private void Awake()
    {
        LoadJSON();

        startPaddingTime[0] = 0f;
        startPaddingTime[1] = 3.6f;
        startPaddingTime[2] = 3f;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame(); // 프레임 잘리는 거 때문에 한 프레임 지연 후 시작

        GameManager.instance.isCutSceneOpen[1] = true;

        StageManager.instance.isPlayingCutScene = true;
        cutscnenePlayer.Play();

        StartCoroutine(StartPost());
    }

    private void Update()
    {
        if(!StageManager.instance.isGameOver && StageManager.instance.yesNoBar.value <= 0f)
        {
            GameOver();
        }
        if(cutsceneIdx > 0)
        {
            IsCutSceneCheck();
            IntoCutScene();
            IntoStage();
        }
    }

    private void GameOver()
    {
        GameManager.instance.isCutSceneOpen[GameManager.instance.isCutSceneOpen.Count - 1] = true;

        StageManager.instance.isGameOver = true;

        StageManager.instance.mainMusic.Stop();

        StartCoroutine(WaitGameOverFadeOut());
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

    private void IsCutSceneCheck()
    {
        if (bgm.time >= cutscene[idx].srtTime - 7f)
        {
            StageManager.instance.isCantMakeNote = true;
        }

        if (bgm.time >= cutscene[idx].endTime + startPaddingTime[idx])
        {
            StageManager.instance.isCantMakeNote = false;
            idx++;
        }
    }

    private void IntoCutScene()
    {
       if (!StageManager.instance.isPlayingCutScene && bgm.time >= cutscene[StageManager.instance.curStage].srtTime - 2f)
       {
            StageManager.instance.isPlayingCutScene = true;
            SetCutScene();
            cutscnenePlayer.Play();

            for (int i = StageManager.instance.inputNoteIdx; i < StageManager.instance.notes.Count; i++)
            {
                if(cutscene[idx].endTime + startPaddingTime[idx] <= StageManager.instance.notes[i].srtTime - StageManager.instance.noteRespawnTime)
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
            cutscnenePlayer.Stop();
            cutsceneIdx += 2;

            // 스테이지 교환
            stage[StageManager.instance.curStage].SetActive(false);
            StageManager.instance.curStage++;

            if (StageManager.instance.curStage == 3)
            {
                cutSceneCanvas.SetActive(false);
                totalStage.SetActive(false);

                if(StageManager.instance.maxCombo < StageManager.instance.combo)
                {
                    StageManager.instance.maxCombo = StageManager.instance.combo;
                }

                scoreStage.SetActive(true);

                gameObject.SetActive(false);
            }
            else
            {
                stage[StageManager.instance.curStage].SetActive(true);

                // 스테이지 전환
                fade.Fade(1, 0, 1);

                StageManager.instance.isPlayingCutScene = false;
            }
        }
    }

    private void ClearRenderTexture()
    {
        RenderTexture.active = renderTexture; // 컷씬용 렌더러 텍스처를 현재 활성화된 렌더러 텍스처로 지정해서
        GL.Clear(true, true, Color.black); // 검정색으로 다 덮음
    }

    private void SetCutScene()
    {
        if(idx == 2) // End
        {
            cutsceneIdx = cutScenes.Length - 2;
            GameManager.instance.isCutSceneOpen[GameManager.instance.isCutSceneOpen.Count - 2] = true;
        }
        else if(StageManager.instance.yesNoBar.value <= 0.4f) // Fail
        {
            cutsceneIdx = (idx * 2) + 2;
            GameManager.instance.isCutSceneOpen[cutsceneIdx + 2] = true;
        }
        else // Success
        {
            cutsceneIdx = (idx * 2) + 1;
            GameManager.instance.isCutSceneOpen[cutsceneIdx + 1] = true;
        }

        cutscnenePlayer.clip = cutScenes[cutsceneIdx];
    }

    IEnumerator StartPost()
    {
        yield return new WaitUntil(() => (!cutscnenePlayer.isPlaying || Input.GetKeyDown(KeyCode.Space)));

        cutscnenePlayer.Stop();
        ClearRenderTexture();

        postCamera.SetActive(false);
        skipButton.SetActive(false);
        cutsceneIdx++;
        StageManager.instance.isPlayingCutScene = false;
        StageManager.instance.curStage = 0;
        totalStage.SetActive(true);

        yield break;
    }

    IEnumerator WaitGameOverCutScene()
    {
        yield return new WaitUntil(() => (!cutscnenePlayer.isPlaying));

        GameOverObj.SetActive(true);
    }

    IEnumerator WaitGameOverFadeOut()
    {
        StageManager.instance.isCantMakeNote = true;
        StageManager.instance.isPlayingCutScene = true;

        cutsceneIdx = cutScenes.Length - 1;
        cutscnenePlayer.clip = cutScenes[cutsceneIdx];

        yield return StartCoroutine(fade.FadeInOut(0, 1, 1));

        totalStage.SetActive(false);
        postCamera.SetActive(true);

        StartCoroutine(WaitGameOverCutScene());
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