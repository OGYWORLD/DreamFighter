using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// stage03의 인트로 동작 스크립트 입니다.
/// </summary>
public class CIntroInvert : MonoBehaviour
{
    public Renderer hologram;
    public Renderer display;

    public GameObject leftCameraObj;
    public GameObject rightCameraObj;

    private Vector3 targetPos = new Vector3(0.24f, 8.74f, 0f);
    private Quaternion targetRotation = Quaternion.Euler(34.42f, 0f, 0f);

    public GameObject gameUI;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        display.material = hologram.material;
        gameObject.GetComponent<Renderer>().material = hologram.material;

        yield return new WaitForSeconds(1f);

        float sumTime = 0f;
        float totalTime = 1.6f;

        Vector3 initPos = leftCameraObj.transform.position;
        Vector3 finPos = leftCameraObj.transform.position + new Vector3(3f, 0f, 0f);

        Camera leftCamera = leftCameraObj.GetComponent<Camera>();
        Camera rightCamera = rightCameraObj.GetComponent<Camera>();

        while (sumTime <= totalTime)
        {
            float t = sumTime / totalTime;
            leftCameraObj.transform.position = Vector3.Lerp(initPos, finPos, t);

            sumTime += Time.deltaTime;

            yield return null;
        }

        leftCamera.rect = new Rect(0f, 0f, 0.7f, 1f);
        gameUI.SetActive(true);
        rightCameraObj.SetActive(true);

        yield break;
    }
}
