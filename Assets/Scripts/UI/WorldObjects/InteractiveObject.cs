using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class InteractiveObject : MonoBehaviour
{

    private Renderer rend;

    private Material normalMaterial;
    public Material highlightedMaterial;

    private Vector3 originalScale;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        normalMaterial = rend.material;

        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        //rend.material = highlightedMaterial;
        transform.localScale = originalScale * 1.1f;
    }

    private void OnMouseExit()
    {
        //rend.material = normalMaterial;
        transform.localScale = originalScale;
    }

}
