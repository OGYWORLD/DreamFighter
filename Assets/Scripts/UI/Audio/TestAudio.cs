using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class TestAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable()
    {
        if(audioSource != null)
        {
            audioSource.Play();
            print("¿Àµð¿À Àç»ýµÊ");
        }
    }

    private void OnDisable()
    {
        audioSource.Pause();
        print("¿Àµð¿À ¸ØÃã");
    }

    private void Update()
    {
        // È®ÀÎ¿ë
        print(audioSource.volume);
    }
}
