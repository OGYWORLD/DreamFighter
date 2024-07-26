using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion 

public class SetInteractable : MonoBehaviour
{
    InteractiveObject[] interactiveObjects;

    public bool isInteractable { get; set; } = false;

    private void Awake()
    {
        interactiveObjects = FindObjectsOfType<InteractiveObject>();

        // ó������ Ȱ��ȭ���� �ʰԲ�
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
