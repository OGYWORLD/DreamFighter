using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActiveTitle : MonoBehaviour
{
    public GameObject cutscene;
    public GameObject title;

    private void Update()
    {
        if(!cutscene.activeSelf)
        {
            title.SetActive(true);
        }
    }
}
