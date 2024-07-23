using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CEndingAnim : MonoBehaviour
{
    public enum Rank
    {
        SRank,
        ARank,
        BRank,
        CRank
    }

    public GameObject title;
    public GameObject[] category;
    public GameObject nextButton;

    public bool isAlreadyShow { get; set; } = false;

    public GameObject fullCombo;

    public GameObject[] rank;

    private int fullComboCnt = 183;

    private IEnumerator Start()
    {
        if (StageManager.instance.maxCombo == fullComboCnt) // full combo
        {
            fullCombo.SetActive(true);
        }

        // 랭크 계산
        int maxScore = 100 * fullComboCnt * (fullComboCnt / 10);
        if(StageManager.instance.score >= maxScore * 0.9)
        {
            rank[(int)Rank.SRank].SetActive(true);
        }
        else if (StageManager.instance.score  >= maxScore * 0.5)
        {
            rank[(int)Rank.ARank].SetActive(true);
        }
        else if (StageManager.instance.score >= maxScore * 0.1)
        {
            rank[(int)Rank.BRank].SetActive(true);
        }
        else
        {
            rank[(int)Rank.CRank].SetActive(true);
        }


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
