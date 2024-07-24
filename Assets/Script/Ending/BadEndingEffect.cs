using UnityEngine;

#region ±Ë«œ¿∫
#endregion

public class BadEndingEffect : MonoBehaviour
{
    public SpriteRenderer Sprite;

    private void Start()
    {
        Invoke("Disappear", 1.3f);
    }

    void Disappear()
    {
        FadeControl.Instance.SpriteAlpha(Sprite, 1f, 0f, 2f);
    }
}