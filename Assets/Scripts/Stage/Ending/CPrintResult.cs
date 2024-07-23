using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#region ¿À°¡À»
#endregion

public class CPrintResult : MonoBehaviour
{
    public TextMeshProUGUI perfectTMP;
    public TextMeshProUGUI goodTMP;
    public TextMeshProUGUI missTMP;
    public TextMeshProUGUI maxComboTMP;
    public TextMeshProUGUI scoreTMP;

    private void Awake()
    {
        StageManager.instance.score = (StageManager.instance.score * (StageManager.instance.maxCombo / 10));
    }

    private void Start()
    {
        perfectTMP.text = "" + StageManager.instance.perfectCnt;
        goodTMP.text = "" + StageManager.instance.goodCnt;
        missTMP.text = "" + StageManager.instance.wrCnt;
        maxComboTMP.text = "" + StageManager.instance.maxCombo;
        scoreTMP.text = "" + StageManager.instance.score;
    }
}
