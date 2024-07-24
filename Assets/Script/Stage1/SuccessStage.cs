using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class SuccessStage : MonoBehaviour
{
    public GameObject GameBoy;
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        GameBoy.SetActive(true);

        Invoke("Success", 6f);
    }

    void Success()
    {
        Anim.SetTrigger("Success");
    }
}