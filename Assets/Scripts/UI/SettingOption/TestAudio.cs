using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class TestAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable()
    {
        if(audioSource != null)
        {
            audioSource.Play();
            print("����� �����");
        }
    }

    private void OnDisable()
    {
        audioSource.Pause();
        print("����� ����");
    }

    private void Update()
    {
        // Ȯ�ο�
        print(audioSource.volume);
    }
}
