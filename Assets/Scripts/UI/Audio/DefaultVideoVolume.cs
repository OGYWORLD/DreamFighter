using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

#region ¿ìÀÎÇý
#endregion

public class DefaultVideoVolume : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        StartCoroutine(setVideoVolumeCoroutine());
    }

    IEnumerator setVideoVolumeCoroutine()
    {
        yield return new WaitForEndOfFrame();
        videoPlayer.SetDirectAudioVolume(0, AudioManager.Instance.masterVolume);
    }
}
