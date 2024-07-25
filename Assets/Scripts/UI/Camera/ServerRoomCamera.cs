using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

public class ServerRoomCamera : MonoBehaviour
{
    public GameObject WorldObjBtn;
    private MainCanvasDictionary mainCVSDic;

    public GameObject[] WorldObjInfo;

    // ������ �̷���� �ð�
    float duration = 3f;

    #region Camera Interpolation Data

    readonly Vector3 startPos = new Vector3(-19.29447f, 1.38461f, -4.52688f);
    readonly Quaternion startRotation = Quaternion.Euler(new Vector3(8.458f, -1.855f, -0.024f));

    readonly Vector3 endPos = new Vector3(-18.39642f, 2.063339f, -6.904736f);
    readonly Quaternion endRotation = Quaternion.Euler(new Vector3(8.114f, -16.466f, -0.027f));

    #endregion

    private void Start()
    {
        

        Time.timeScale = 1f;

        WorldObjBtn.gameObject.SetActive(true);

        InitTransform();
        StartCoroutine(TransformInterpolation());

        mainCVSDic = FindObjectOfType<MainCanvasDictionary>();
        SetInfo(false);
    }

    void InitTransform()
    {
        transform.position = startPos;
        transform.rotation = startRotation;

        //print("Server Room ī�޶� ���� ��ġ �ʱ�ȭ �Ϸ�");
    }

    IEnumerator TransformInterpolation()
    {
        //print("Server Room ī�޶� �ʱ� �̵� ����");

        float delta = 0.0f;

        while(delta <= duration)
        {
            float t = delta / duration;
            transform.position = Vector3.Slerp(startPos, endPos, t);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            delta += Time.deltaTime;

            yield return null;
        }

        //print("Server Room ī�޶� �ʱ� �̵� ����");

        SetInfo(true);
    }

    void SetInfo(bool b)
    {
        //if(MainCanvasDictionary.Instance.canvasDic[CanvasNamesEnum.MainMenuInfoCVS] == null)
        //{
        //    return;
        //}

        //mainCVSDic.canvasDic[CanvasNamesEnum.MainMenuInfoCVS].gameObject.SetActive(b);

        foreach (GameObject obj in WorldObjInfo)
        {
            obj.gameObject.SetActive(b);
        }
    }


}
