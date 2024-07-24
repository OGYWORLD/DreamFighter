using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ¿ìÀÎÇý
#endregion

public class CloseButton : MonoBehaviour
{
    CloseButtonSource closeBtnSource;
    AudioSource audioSource;
    AudioClip audioClip;

    const string closeClip = "CloseSound";

    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();

        closeBtnSource = FindObjectOfType<CloseButtonSource>();
    }

    private void Start()
    {
        audioSource = closeBtnSource.GetComponent<AudioSource>();
        btn.onClick.AddListener(OnCloseBtnClicked);
        audioClip = AudioManager.Instance.GetAudioClip(closeClip);
    }

    void OnCloseBtnClicked()
    {
        audioSource.PlayOneShot(audioClip);

        print($"close button Clicked: {audioSource.volume}");
    }
}
