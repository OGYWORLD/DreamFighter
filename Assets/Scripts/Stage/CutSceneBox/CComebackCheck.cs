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

    public AudioSource bgm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EndCutScene();
        }
    }

    private void OnEnable()
    {
        bgm.Pause();

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

        bgm.UnPause();

        gameObject.SetActive(false);
    }
}
