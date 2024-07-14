using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

/// <summary>
/// ȭ�� ��ܿ� �����ϴ� YesNo ������ �ٸ� �����ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CYesNoBar : MonoBehaviour
{
    private void Start()
    {
        StageManager.instance.yesNoBar.value = 1f;

        StartCoroutine(UpdateBar());
    }

    // �������ٴ� ���� ���� * 0.00001f�� ����
    IEnumerator UpdateBar()
    {
        yield return new WaitUntil(() => (StageManager.instance.mainMusic.isPlaying 
        && StageManager.instance.mainMusic.time >= StageManager.instance.notes[0].srtTime - 1f));

        while(StageManager.instance.mainMusic.isPlaying)
        {
            StageManager.instance.yesNoBar.value -= StageManager.instance.mainMusic.clip.length * 0.00001f;

            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }
}
