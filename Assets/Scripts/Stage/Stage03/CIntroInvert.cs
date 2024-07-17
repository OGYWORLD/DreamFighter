using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

/// <summary>
/// stage03�� ��Ʈ�� ���� ��ũ��Ʈ �Դϴ�.
/// </summary>
public class CIntroInvert : MonoBehaviour
{
    public Renderer hologram;
    public Renderer display;

    public GameObject loading;

    public GameObject leftCameraObj;
    public GameObject rightCameraObj;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        display.material = hologram.material;
        gameObject.GetComponent<Renderer>().material = hologram.material;
        loading.SetActive(false);

        yield return new WaitForSeconds(1f);

        float sumTime = 0f;
        float totalTime = 2f;

        Vector3 initPos = leftCameraObj.transform.position;
        Vector3 targetPos = leftCameraObj.transform.position + new Vector3(0f, 0f, 3f);

        while(sumTime <= totalTime)
        {
            float t = sumTime / totalTime;
            leftCameraObj.transform.position = Vector3.Lerp(initPos, targetPos, t);

            sumTime += Time.deltaTime;

            yield return null;
        }

        Camera rightCamera = leftCameraObj.GetComponent<Camera>();
        rightCameraObj.SetActive(true);
        rightCamera.rect = new Rect(0f, 0f, 0.5f, 1f);

        yield break;
    }
}
