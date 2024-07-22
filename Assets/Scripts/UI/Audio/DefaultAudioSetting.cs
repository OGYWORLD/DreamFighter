using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class DefaultAudioSetting : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SetAudioVolume();
    }

    void SetAudioVolume()
    {
        audioSource.volume = AudioManager.Instance.masterVolume;
    }
}
