using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DefaultAudioSetting))]
public class ObjHoverSound : MonoBehaviour
{
    AudioSource audioSource;
    const string hoverSound = "HoverSound";


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = AudioManager.Instance.GetAudioClip(hoverSound);
    }

    private void OnMouseEnter()
    {
        if(audioSource.clip == null)
        {
            return;
        }

        audioSource.Play();
        //print("hover sound played");
    }
}
