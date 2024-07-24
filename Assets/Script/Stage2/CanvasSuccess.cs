using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class CanvasSuccess : MonoBehaviour
{
    public GameObject TextBox;

    private void Start()
    {
        Invoke("PopUp", 9f);
    }

    void PopUp()
    {
        TextBox.SetActive(true);
    }
}