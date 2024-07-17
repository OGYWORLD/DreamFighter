using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// stage03에서 메쉬 머트리얼을 홀로그램으로 변환하는 스크립트 입니다.
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
