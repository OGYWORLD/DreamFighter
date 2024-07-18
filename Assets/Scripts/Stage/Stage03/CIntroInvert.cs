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

    public GameObject checkZone;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        display.material = hologram.material;
        gameObject.GetComponent<Renderer>().material = hologram.material;

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
        checkZone.SetActive(true);
        rightCameraObj.SetActive(true);
        rightCamera.rect = new Rect(0f, 0f, 0.5f, 1f);

        yield break;
    }
}
