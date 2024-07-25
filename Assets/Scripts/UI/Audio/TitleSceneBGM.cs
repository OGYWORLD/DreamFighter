using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class TitleSceneBGM : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = audioSource.loop = true;
    }
}
