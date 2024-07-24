using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 우인혜
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

        audioSource.Play();
        audioSource.loop = true;

        //todo: 메인 씬 BGM 원하는 오디오클립으로 바꿔주기

        //print("main BGM played");
    }


}
