using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();
    }
}
