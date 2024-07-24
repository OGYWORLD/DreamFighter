using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class CharactorMaintain : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, 6f);
    }
}