using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region ±Ë«œ¿∫
#endregion

public class LoadSciFiScene : MonoBehaviour
{
    public Material Emission;
    private Color StartEmission = Color.white;
    private Color EndEmission = Color.black;
    public Image Black;

    private void Start()
    {
        Invoke("ChangeEmission", 35f);
        Invoke("LoadScene", 37f);
    }

    void ChangeEmission()
    {
        FadeControl.Instance.AlphaChange(Emission, 1f, 1f, StartEmission, EndEmission, 2f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("RequestScene");
    }
}