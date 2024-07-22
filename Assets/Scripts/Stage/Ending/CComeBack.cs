using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 오가을
#endregion

public class CComeBack : MonoBehaviour
{
    public CEndingAnim endingAnim;
    private void Update()
    {
       if(endingAnim.isAlreadyShow && Input.GetKeyDown(KeyCode.Space))
       {
            // 홈화면으로 이동
       }
    }
}
