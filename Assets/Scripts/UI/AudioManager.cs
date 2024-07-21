using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ������
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

    /// <summary>
    /// ���ο� ���� �ε�� �� �ش� ���� ����� �ҽ� ������ ������ �������� ����
    /// </summary>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetSceneVolume();
    }
}
