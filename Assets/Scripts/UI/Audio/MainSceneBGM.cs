using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
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

        //todo: ���� �� BGM ���ϴ� �����Ŭ������ �ٲ��ֱ�

        //print("main BGM played");
    }


}
