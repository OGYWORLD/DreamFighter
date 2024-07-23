using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance { get; private set; }

    public bool isOpenMenu { get; set; } = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
}
