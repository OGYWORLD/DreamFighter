using UnityEngine;

#region ������
#endregion

public class CanvasFail : MonoBehaviour
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