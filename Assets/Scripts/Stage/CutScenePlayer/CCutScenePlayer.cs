using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using UnityEngine.Video;

#region ������
#endregion

/// <summary>
/// ������������ �ƾ� ��ȯ, �ƾ����� �������� ��ȯ�� �ϴ� ��ũ��Ʈ�Դϴ�.
/// </summary>
public class CCutScenePlayer : MonoBehaviour
{
    public AudioSource bgm; // �������

    public GameObject cutSceneCanvas; // �ƾ� ĵ����
    public VideoPlayer cutScenePlayer; // �ƾ� ���� �÷��̾�

    private List<CutScene> cutscene = new List<CutScene>(); // �ƾ� ����, ���Ḧ ���� ����Ʈ

    private int idx = 0; // �ƾ� ����Ʈ �ε���

    public GameObject[] stage = new GameObject[3]; // ��������

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
            // �뷡 ���� ����


            // �ƽ� ��ȯ
            cutSceneCanvas.SetActive(true);
            cutScenePlayer.Play();

            // ��Ʈ idx �ǳʶپ������
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
            // �������� ��ȯ
            cutSceneCanvas.SetActive(false);
            cutScenePlayer.Stop();

            // ��Ʈ �ε��� ������Ʈ�� 2��° ������������ CShowLazer�� ������� �ʰ� ���� ��ũ��Ʈ �ļ�
            // Ǯ������ �ű� ������ �� ��ũ��Ʈ���� StageManager.instance.inputNoteIdx ���� Ȱ��ȭ������ ����ִ� ������� �����ҿ���

            // �������� ��ȯ
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