using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class MainSceneBGM : MonoBehaviour
{
    AudioSource audioSource;
    const string mainBGM = "MainSceneBGM";

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = AudioManager.Instance.GetAudioClip(mainBGM);
        SetMainBGMVolume();

        audioSource.Play();
        audioSource.loop = true;

        //print("main BGM played");
    }



    void SetMainBGMVolume()
    {
        audioSource.volume = AudioManager.Instance.masterVolume * 2 / 3;
    }

    public void SetMainBGMVolume(float volume)
    {
        audioSource.volume = volume * 2 / 3;
    }

    


}
