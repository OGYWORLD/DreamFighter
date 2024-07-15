using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputSound : MonoBehaviour
{
    public AudioSource clickSound;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            clickSound.Play();
        }
    }
}
