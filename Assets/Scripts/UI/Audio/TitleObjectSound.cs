using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class TitleObjectSound : MonoBehaviour
{
    public AudioSource flyInAudio;
    public AudioSource flyOutAudio;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        flyInAudio.playOnAwake = flyOutAudio.playOnAwake = false;
        flyInAudio.loop = flyOutAudio.loop = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        flyInAudio.Play();
        //print("fly in sound");

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Fly Out"))
        {
            flyOutAudio.Play();
        }
    }
}
