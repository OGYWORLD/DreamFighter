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
        audioSource.clip = AudioManager.Instance.GetAudioClip(closeClip);
    }

    private void OnDisable()
    {
        btn.onClick.RemoveListener(OnCloseBtnClicked);
    }

    void OnCloseBtnClicked()
    {
        audioSource.Play();

        print($"close button Clicked: {audioSource.volume}");
    }
}
