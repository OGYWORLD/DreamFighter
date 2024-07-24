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

    const string openSound = "OpenSound";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       

        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        audioSource.clip = AudioManager.Instance.GetAudioClip(openSound);
    }

    private void OnEnable()
    {
        audioSource.Play();
        //print("open sound played");
    }
}
