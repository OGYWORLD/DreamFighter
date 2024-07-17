using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// stage03���� �޽� ��Ʈ������ Ȧ�α׷����� ��ȯ�ϴ� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CIntroInvert : MonoBehaviour
{
    public Renderer hologram;
    public Renderer display;

    public GameObject loading;

    public GameObject mainCamera;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        display.material = hologram.material;
        gameObject.GetComponent<Renderer>().material = hologram.material;
        loading.SetActive(false);

        yield return new WaitForSeconds(1f);

        float sumTime = 0f;
        float totalTime = 2f;

        Vector3 initPos = mainCamera.transform.position;
        Vector3 targetPos = mainCamera.transform.position + new Vector3(0f, 0f, 3f);

        while(sumTime <= totalTime)
        {
            float t = sumTime / totalTime;
            mainCamera.transform.position = Vector3.Lerp(initPos, targetPos, t);

            sumTime += Time.deltaTime;

            yield return null;
        }

        yield break;
    }
}
