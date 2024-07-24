using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class SciFiNeonScene : MonoBehaviour
{
    private Animator Anim;
    public GameObject Robot;
    public GameObject SavePoint;

    private void Start()
    {
        Anim = GetComponent<Animator>();

        Invoke("LookingAround", 15f);
        Invoke("Running", 26.5f);
        Invoke("AppearBoss", 26f);
        Invoke("StopRunning", 29.5f);
        Invoke("Hiding", 36f);
        Invoke("ToSave", 41f);
        Invoke("ToWalk", 45f);
        Invoke("Disappear", 46.5f);
        Invoke("StopWalk", 46.5f);
        Invoke("End", 53f);
    }

    void LookingAround()
    {
        Anim.SetTrigger("isLooking");
    }

    void Running()
    {
        Anim.SetBool("isRunning", true);
    }

    void StopRunning()
    {
        Anim.SetTrigger("Stop");
        Anim.SetBool("isRunning", false);
    }

    void Hiding()
    {
        Anim.SetTrigger("isHiding");
    }

    void AppearBoss()
    {
        Robot.SetActive(true);
    }

    void ToSave()
    {
        SavePoint.SetActive(true);
    }

    void ToWalk()
    {
        Anim.SetBool("isWalking", true);
    }

    void StopWalk()
    {
        Anim.SetBool("isRunning", false);
        Anim.SetTrigger("ToStop");
    }

    void Disappear()
    {
        SavePoint.SetActive(false);
    }

    void End()
    {
        Anim.SetTrigger("isFail");
        Anim.SetTrigger("isSad");
    }
}