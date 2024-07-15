using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

public class StartKeyInfo : MonoBehaviour
{
    Graphic StartInfo;
    public float distanceTime = 0.8f;

    private void Awake()
    {
        StartInfo = GetComponent<Graphic>();
    }

    void Start()
    {
        StartCoroutine(BlinkInfoCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// Press Any Key�� �����Ÿ����� �ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns>1�� ����</returns>
    IEnumerator BlinkInfoCoroutine()
    {
        while (true)
        {
            Color currentColor = StartInfo.color;
            currentColor.a = currentColor.a == 1 ? 0 : 1;
            StartInfo.color = currentColor;

            yield return new WaitForSeconds(distanceTime);
        }
    }
}
