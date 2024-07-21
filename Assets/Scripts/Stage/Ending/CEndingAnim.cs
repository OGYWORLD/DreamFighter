using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ¿À°¡À»
#endregion

public class CEndingAnim : MonoBehaviour
{
    public GameObject title;
    public GameObject[] category;
    public GameObject nextButton;

    public bool isAlreadyShow { get; set; } = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.6f);

        title.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        for(int i = 0; i < category.Length; i++)
        {
            category[i].SetActive(true);

            yield return new WaitForSeconds(0.3f);
        }

        isAlreadyShow = true;

        nextButton.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isAlreadyShow = true;
            SkipShow();
        }
    }

    private void SkipShow()
    {
        title.SetActive(true);

        for (int i = 0; i < category.Length; i++)
        {
            category[i].SetActive(true);
        }

        nextButton.SetActive(true);
    }
}
