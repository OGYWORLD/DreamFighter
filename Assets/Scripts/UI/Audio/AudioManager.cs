using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region ������
#endregion

[Serializable]
public class AudioClipInfo
{
    public string name;
    public AudioClip audioclip;
}

public class AudioManager : Singleton<AudioManager>
{
    public float masterVolume = 0.5f;
    public List<AudioClipInfo> audioList = new();
    public Dictionary<string, AudioClip> audioDic = new();

    private void Awake()
    {
        ListToDict();
    }

    void ListToDict()
    {
        foreach (AudioClipInfo info in audioList)
        {
            audioDic.Add(info.name, info.audioclip);
        }

        audioList = null;
    }

    /// <summary>
    /// masterVolume�� �� ���� �޾Ƽ� �ش� ������ ���� ���� ������ҽ� ���� ����
    /// </summary>
    /// <param name="volume">0���� 1</param>
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;

        SetSceneVolume();
    }

    /// <summary>
    /// �� �ȿ� �ִ� ����� �ҽ� ������ �ϰ� ����
    /// </summary>
    public void SetSceneVolume()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    public AudioClip GetAudioClip(string name)
    {
        return audioDic[name];
    }
}
