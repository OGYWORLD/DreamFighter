using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DefaultAudioSetting))]
public class InfoOpenSound : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;

    const string infoSound = "InfoOpenSound";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = AudioManager.Instance.GetAudioClip(infoSound);

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
