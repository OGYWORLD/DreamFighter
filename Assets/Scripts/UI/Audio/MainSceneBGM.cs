using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class MainSceneBGM : MonoBehaviour
{
    AudioSource audioSource;

    const string mainBGM = "MainSceneBGM";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    private void Start()
    {
        audioSource.clip = AudioManager.Instance.GetAudioClip(mainBGM);
        audioSource.Play();
    }
}
