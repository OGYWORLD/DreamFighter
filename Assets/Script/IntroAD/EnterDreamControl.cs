using UnityEngine;
using UnityEngine.SceneManagement;

#region ������
#endregion

public class EnterDreamControl : MonoBehaviour
{
    private void Start()
    {
        Invoke("ChangeDream", 3f);
    }

    void ChangeDream()
    {
        SceneManager.LoadScene("ChangeDream");
    }
}