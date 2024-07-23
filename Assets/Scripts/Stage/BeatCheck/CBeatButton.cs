using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class CBeatButton : MonoBehaviour
{
    public AudioSource clickSound;

    public GameObject okPopup;

    public void OnReset()
    {
        if(!MenuManager.instance.isOpenMenu)
        {
            GameManager.instance.beatPadding = 0f;

            clickSound.Play();
            okPopup.SetActive(true);

            StartCoroutine(SetHidePopup());
        }
    }

    IEnumerator SetHidePopup()
    {
        yield return new WaitForSeconds(2f);

        okPopup.SetActive(false);
    }
}
