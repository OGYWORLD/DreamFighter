using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class ChestControl : MonoBehaviour
{
    private Animator Anim;
    public GameObject Light;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Invoke("Open", 2f);
    }

    void Open()
    {
        Light.SetActive(true);
        Anim.SetTrigger("isOpen");
    }
}