using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CLazerIput : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
