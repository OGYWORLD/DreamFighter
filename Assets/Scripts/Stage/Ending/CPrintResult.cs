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

    private void Start()
    {
        perfectTMP.text = "" + StageManager.instance.perfectCnt;
        goodTMP.text = "" + StageManager.instance.goodCnt;
        missTMP.text = "" + StageManager.instance.wrCnt;
        maxComboTMP.text = "" + StageManager.instance.maxCombo;
        scoreTMP.text = "" + StageManager.instance.score;
    }
}
