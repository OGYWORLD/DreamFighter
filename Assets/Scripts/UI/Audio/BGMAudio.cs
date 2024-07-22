using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class BGMAudio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = AudioManager.Instance.audioDic["BGM"];
        audioSource.clip = audioClip;
        audioSource.volume = AudioManager.Instance.masterVolume;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        audioSource.Play();
    }

}
