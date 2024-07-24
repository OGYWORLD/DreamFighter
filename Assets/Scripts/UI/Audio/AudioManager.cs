using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

#region 우인혜
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

    private void Start()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
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
    /// masterVolume에 새 값을 받아서 해당 값으로 현재 씬의 오디오소스 볼륨 변경
    /// </summary>
    /// <param name="volume">0에서 1</param>
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;

        SetSceneVolume();
    }

    /// <summary>
    /// 씬 안에 있는 오디오 소스 볼륨을 일괄 변경
    /// </summary>
    public void SetSceneVolume()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    public void SetSceneVolume(AudioSource[] audioSources)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = masterVolume;
        }
    }

    public AudioClip GetAudioClip(string name)
    {
        return audioDic[name];
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetVolumeNewScene();
    }

    private void SetVolumeNewScene()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        AudioManager.Instance.SetSceneVolume(audioSources);
    }
}
