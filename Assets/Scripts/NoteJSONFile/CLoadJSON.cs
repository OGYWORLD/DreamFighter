using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

#region 오가을
#endregion

/// <summary>
/// JSON으로 작성된 Note 정보 파일을 가져오는 스크립트 입니다.
/// CMakeNote 스크립트를 통해 JSON 파일을 생성 후 해당 스크립트로 JSON을 불러와서 사용하면 됩니다.
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
