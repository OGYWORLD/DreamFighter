using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBeatCheck : MonoBehaviour
{
    public AudioSource beepSound;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        int beepCount = 10;
        int index = 0;
        while(index < beepCount)
        {
            beepSound.Play();

            yield return new WaitForSeconds(1f);
            index++;
        }
    }
}
