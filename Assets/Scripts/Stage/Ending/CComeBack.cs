using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ������
#endregion

public class CComeBack : MonoBehaviour
{
    public CEndingAnim endingAnim;
    private void Update()
    {
       if(endingAnim.isAlreadyShow && Input.GetKeyDown(KeyCode.Space))
       {
            // Ȩȭ������ �̵�
       }
    }
}
