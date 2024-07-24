using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#region ±Ë«œ¿∫
#endregion

public class FadeControl : MonoBehaviour
{
    private static FadeControl _instance;

    public static FadeControl Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("FadeControl");
                _instance = obj.AddComponent<FadeControl>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public Coroutine StartFadeOut(Image image, float StartAlpha, float EndAlpha, float FadeSpeed)
    {
        return StartCoroutine(FadeOut(image, StartAlpha, EndAlpha, FadeSpeed));
    }

    private IEnumerator FadeOut(Image image, float StartAlpha, float EndAlpha, float FadeSpeed)
    {
        Color color = image.color;
        float elapsedTime = 0f;

        while (elapsedTime < FadeSpeed && image != null)
        {
            float normalizedTime = elapsedTime / FadeSpeed;
            color.a = Mathf.Lerp(StartAlpha, EndAlpha, normalizedTime);
            image.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (image != null)
        {
            color.a = EndAlpha;
            image.color = color;
        }

        yield return null;
    }

    public Coroutine SpriteAlpha(SpriteRenderer Sprite, float StartAlpha, float EndAlpha, float FadeSpeed)
    {
        return StartCoroutine(SpriteControl(Sprite, StartAlpha, EndAlpha, FadeSpeed));
    }

    private IEnumerator SpriteControl(SpriteRenderer Sprite, float StartAlpha, float EndAlpha, float FadeSpeed)
    {
        Color color = Sprite.color;
        float elapsedTime = 0f;

        while (elapsedTime < FadeSpeed && Sprite != null)
        {
            float normalizedTime = elapsedTime / FadeSpeed;
            color.a = Mathf.Lerp(StartAlpha, EndAlpha, normalizedTime);
            Sprite.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (Sprite != null)
        {
            color.a = EndAlpha;
            Sprite.color = color;
        }

        yield return null;
    }

    public Coroutine AlphaChange(Material material, float StartAlpha, float EndAlpha, Color StartEmission, Color EndEmission, float FadeSpeed)
    {
        return StartCoroutine(AlphaControl(material, StartAlpha, EndAlpha, StartEmission, EndEmission, FadeSpeed));
    }

    private IEnumerator AlphaControl(Material material, float StartAlpha, float EndAlpha, Color StartEmission, Color EndEmission, float FadeSpeed)
    {
        Color color = material.color;

        float elapsedTime = 0f;

        while (elapsedTime < FadeSpeed && material != null)
        {
            float normalizedTime = elapsedTime / FadeSpeed;

            color.a = Mathf.Lerp(StartAlpha, EndAlpha, normalizedTime);
            material.color = color;

            Color NowEmission = Color.Lerp(StartEmission, EndEmission, normalizedTime);
            material.SetColor("_EmissionColor", NowEmission);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (material != null)
        {
            color.a = EndAlpha;
            material.color = color;

            material.SetColor("_EmissionColor", EndEmission);
        }

        yield return null;
    }
}