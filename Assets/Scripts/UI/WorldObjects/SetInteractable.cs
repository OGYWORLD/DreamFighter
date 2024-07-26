using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 우인혜
#endregion 

public class SetInteractable : MonoBehaviour
{
    InteractiveObject[] interactiveObjects;

    public bool isInteractable { get; set; } = false;

    private void Awake()
    {
        interactiveObjects = FindObjectsOfType<InteractiveObject>();

        // 처음에는 활성화되지 않게끔
        setActiveInteraction(false);
    }

    //IEnumerator

    public void setActiveInteraction(bool b)
    {
        foreach (InteractiveObject obj in interactiveObjects)
        {
            Collider collider = obj.GetComponent<Collider>();

            if(collider != null)
            {
                collider.enabled = b;
            }
        }
    }
}
