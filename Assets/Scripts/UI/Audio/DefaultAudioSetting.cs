using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class DefaultAudioSetting : MonoBehaviour
{
    AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }

    void SetAudioVolume()
    {
        foreach(AudioSource audio in audioSources)
        {
            audio.volume = AudioManager.Instance.masterVolume;
        }
    }
}
