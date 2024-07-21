using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 우인혜
#endregion


public class AudioManager : Singleton<AudioManager>
{
    public float masterVolume = 0.5f;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

    void Start()
    {
        SetMasterVolume(masterVolume);
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

    /// <summary>
    /// 새로운 씬이 로드될 때 해당 씬의 오디오 소스 볼륨을 마스터 볼륨으로 변경
    /// </summary>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetSceneVolume();
    }
}
