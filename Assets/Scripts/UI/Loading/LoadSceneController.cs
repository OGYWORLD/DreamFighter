using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region ¿ìÀÎÇý
#endregion

public class LoadSceneController : MonoBehaviour
{
    static string nextScene;

    public Slider progressbar;
    public Text count;

    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadSceneAsync("0. Loading");
    }


    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressbar.value = op.progress;

                int intCount = Mathf.RoundToInt(progressbar.value * 100f);
                count.text = intCount.ToString();
                //count = progressbar.value
            }
            else
            {
                
                timer += Time.unscaledDeltaTime;
                progressbar.value = Mathf.Lerp(0.9f, 1f, timer);
                
                int intCount = Mathf.RoundToInt(progressbar.value * 100f);
                count.text = intCount.ToString();

                if (progressbar.value >= 1f)
                {
                    yield return new WaitForSeconds(5f);
                    op.allowSceneActivation = true;
                }

            }
        }
    }
}


/*
 Text progress;
	
	public  void UpdateProgress (float content) {
		progress.text = Mathf.Round( content*100) +"%";
	}
 */