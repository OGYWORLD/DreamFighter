using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class SetAudioVolume : MonoBehaviour
{
    AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }

    private void OnEnable()
    {
        foreach(AudioSource audio in audioSources)
        {
            audio.volume = AudioManager.Instance.masterVolume;
        }
    }
}
