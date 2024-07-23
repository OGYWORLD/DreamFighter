using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

#region 오가을
#endregion

public class CPlayer : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject videoObj;

    public VideoClip[] cutscenes;

    public void OnPlayCutScene(int n)
    {
        player.clip = cutscenes[n];
        videoObj.SetActive(true);
        // 배경음악 일시중지
    }
}
