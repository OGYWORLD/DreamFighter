using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 우인혜
#endregion


public class AudioManager : Singleton<AudioManager>
{
    public float masterVolume = 0.5f;

    void Start()
    {
        SetMasterVolume(masterVolume);
    }

    /// <summary>
    /// 오디오소스 볼륨 변경
    /// </summary>
    /// <param name="volume">0에서 1</param>
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    /// <summary>
    /// 오디오소스 볼륨 변경
    /// </summary>
    /// <param name="volume">0에서 100</param>
    public void SetMasterVolume(int volume)
    {
        masterVolume = Mathf.Clamp01(volume / 100f);

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }
}
