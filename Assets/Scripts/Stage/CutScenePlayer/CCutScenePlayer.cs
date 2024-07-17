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

    private List<CutScene> cutscene = new List<CutScene>(); // �ƾ� ����, ���Ḧ ���� ����Ʈ

    private int idx = 0; // �ƾ� ����Ʈ �ε���

    public GameObject[] stage = new GameObject[3]; // ��������

    public CFadeOutIn fade; // ���̵� �� �ƿ�

    private bool isPlay = false; // �ƾ� ��� ���� (���� ��� ���ο� ���̵� ������ ������ �޶� ������ ó��)

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
            // �������� ��ȯ
            stage[StageManager.instance.curStage].SetActive(false);
            StageManager.instance.curStage++;
            stage[StageManager.instance.curStage].SetActive(true);

            // �������� ��ȯ
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