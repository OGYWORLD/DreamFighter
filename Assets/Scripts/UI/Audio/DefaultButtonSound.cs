using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ¿ìÀÎÇý
#endregion

[RequireComponent(typeof(AudioSource))]
public class DefaultButtonSound : MonoBehaviour
{
    Button btn;
    AudioSource audioSource;
    AudioClip audioClip;

    private void Awake()
    {
        btn = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        audioClip = AudioManager.Instance.GetAudioClip("BtnSound");

        btn.onClick.AddListener(BtnSoundPlay);
    }

    void BtnSoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
