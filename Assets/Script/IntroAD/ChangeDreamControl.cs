using UnityEngine;
using UnityEngine.SceneManagement;

#region ±Ë«œ¿∫
#endregion

public class ChangeDreamControl : MonoBehaviour
{
    public GameObject Charactor;

    private void Start()
    {
        Invoke("Ican", 1.5f);
        Invoke("Night", 2f);
    }

    void Ican()
    {
        Charactor.SetActive(true);
    }

    void Night()
    {
        SceneManager.LoadScene("Night");
    }
}