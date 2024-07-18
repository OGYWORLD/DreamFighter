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

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume / 100f); // 정규화

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach(AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }
}
