using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

#region ¿À°¡À»
#endregion

public class CIntro : MonoBehaviour
{
    public VideoPlayer player;

    public RenderTexture renderTexture;

    public GameObject title;

    private void Start()
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);

        StartCoroutine(CheckEnd());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(EndCutScene());
        }
    }

    private IEnumerator CheckEnd()
    {
        yield return new WaitUntil(() => !player.isPlaying);

        StartCoroutine(EndCutScene());
    }

    private IEnumerator EndCutScene()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);

        gameObject.SetActive(false);

        yield return new WaitForEndOfFrame();
    }
}
