using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

#region ¿À°¡À»
#endregion

public class CComebackCheck : MonoBehaviour
{
    public VideoPlayer player;

    public RenderTexture renderTexture;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EndCutScene();
        }
    }

    private void OnEnable()
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);

        player.Play();

        StartCoroutine(CheckEnd());
    }

    private IEnumerator CheckEnd()
    {
        yield return new WaitUntil(() => !player.isPlaying);

        EndCutScene();
    }

    private void EndCutScene()
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.black);

        gameObject.SetActive(false);
    }
}
