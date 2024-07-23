using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿ìÀÎÇý
#endregion

public class SetParentNull : MonoBehaviour
{
    private void Start()
    {
        transform.SetParent(null);
    }
}
