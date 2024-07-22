using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#region ¿À°¡À»
#endregion

public class CHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();
    }
}
