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
<<<<<<< HEAD
        audioSource.volume = AudioManager.Instance.masterVolume * 3 / 2;

        // print($"current volume: {audioSource.volume}");
=======
        foreach(AudioSource audio in audioSources)
        {
            audio.volume = AudioManager.Instance.masterVolume;
        }
>>>>>>> b4072d1790bde8808e50abc81e0fde594966f601
    }
}
