using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTest : MonoBehaviour
{
    public AudioSource music;

    public void OnClick()
    {
        print(music.time);
    }
}
