using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region ������
#endregion

/// <summary>
/// JSON���� �ۼ��� Note ���� ������ �������� ��ũ��Ʈ �Դϴ�.
/// CMakeNote ��ũ��Ʈ�� ���� JSON ������ ���� �� �ش� ��ũ��Ʈ�� JSON�� �ҷ��ͼ� ����ϸ� �˴ϴ�.
/// </summary>

public class CLoadJSON : MonoBehaviour
{
    private void Start()
    {
        LoadJSON();
    }

    void LoadJSON()
    {
        string path = $"{Application.streamingAssetsPath}/NoteData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            StageManager.instance.notes = JsonConvert.DeserializeObject<List<Note>>(json);
        }
    }
}
