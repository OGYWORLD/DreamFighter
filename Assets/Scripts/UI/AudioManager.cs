using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
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
        masterVolume = Mathf.Clamp01(volume / 100f); // ����ȭ

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach(AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }
}
