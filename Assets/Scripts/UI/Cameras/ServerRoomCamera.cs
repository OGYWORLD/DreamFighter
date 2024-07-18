using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 우인혜
#endregion

public class ServerRoomCamera : MonoBehaviour
{
    // 보간이 이루어질 시간
    float duration = 3f;

    #region Camera Interpolation Data

    readonly Vector3 startPos = new Vector3(-19.29447f, 1.38461f, -4.52688f);
    readonly Quaternion startRotation = Quaternion.Euler(new Vector3(8.458f, -1.855f, -0.024f));

    readonly Vector3 endPos = new Vector3(-18.39642f, 2.063339f, -6.904736f);
    readonly Quaternion endRotation = Quaternion.Euler(new Vector3(8.114f, -16.466f, -0.027f));

    #endregion

    private void Start()
    {
        InitTransform();
        StartCoroutine(TransformInterpolation());
    }

    void InitTransform()
    {
        transform.position = startPos;
        transform.rotation = startRotation;

        print("시작 위치 초기화");
    }

    IEnumerator TransformInterpolation()
    {
        float delta = 0.0f;

        while(delta <= duration)
        {
            float t = delta / duration;
            transform.position = Vector3.Slerp(startPos, endPos, t);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            delta += Time.deltaTime;

            yield return null;
        }
    }

}
