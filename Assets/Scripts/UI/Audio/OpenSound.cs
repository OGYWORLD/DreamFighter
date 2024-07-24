using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DefaultAudioSetting))]
public class OpenSound : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;

    const string openSound = "OpenSound";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = AudioManager.Instance.GetAudioClip(openSound);

        audioSource.loop = false;
        audioSource.playOnAwake = true;

    }

    private void OnEnable()
    {
        audioSource.PlayOneShot(audioClip);
        //audioSource.Play();
        //print("open sound played");
    }
}
