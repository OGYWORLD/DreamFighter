using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonSource : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = audioSource.loop = false;

    }
}
