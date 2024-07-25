using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class TitleSceneBGM : MonoBehaviour
{
    AudioSource audioSource;
    //const string titleBGM = "TitleSceneBGM";

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
        audioSource.loop = true;
    }
}
