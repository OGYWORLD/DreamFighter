using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

#region ������
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
        // ������� �Ͻ�����
    }
}
