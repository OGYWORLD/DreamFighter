using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

#region ������
#endregion

public class UICamera_Main : MonoBehaviour
{
    private Camera cam;

    // UI ���
    public Graphic StartInfo;

    // ���� �����̽��� ��ġ�� Ÿ��Ʋ ������Ʈ
    public GameObject TitleObject;


    #region ī�޶� ���� ����

    /// <summary>
    /// ������ �̷���� �ð�
    /// </summary>
    float duration = 3f;

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ��ġ �ʱⰪ �� ������
    /// </summary>
    readonly Vector3 startPosition = new Vector3(-82.77859f, 15.04829f, 9.848166f);

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ���� �ʱⰪ �� ������
    /// </summary>
    readonly Quaternion startRotation = Quaternion.Euler(new Vector3(354.4679f, 71.50002f, 0f));


    /// <summary>
    /// Ÿ��Ʋ ������ ���� ȭ�������� ��ȯ�� ���� ī�޶� ��ġ ����
    /// </summary>
    readonly Vector3 endPosition = new Vector3(-73.6115f, 12.48918f, -6.53041f);

    /// <summary>
    /// Ÿ��Ʋ ������ ���� ȭ�������� ��ȯ�� ���� ī�޶� ���� ����
    /// </summary>
    //[SerializeField]Quaternion endRotation = Quaternion.Euler(new Vector3(1.582f, 83.333f, 0.003f));
    readonly Quaternion endRotation = Quaternion.Euler(new Vector3(1.582f, 79.3f, 0.003f));

    #endregion

    //========================================================================================================


    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        ShowTitleScreen();

    }

    //========================================================================================================

    void ShowTitleScreen()
    {
        // todo: (����) �� �������� �⺻ BGM�� �������� �ϸ� �ǰڴ�.

        if (!UIManager.Instance.isMainLoadAgain)
        {
            InitCamTransform();
            StartCoroutine(ShowOnceCoroutine());
            UIManager.Instance.isMainLoadAgain = true;
        }
        else
        {
            StartInfo.gameObject.SetActive(false);
            TitleObject.gameObject.SetActive(false);

            StartCoroutine(ShowMainScreenCoroutine());
        }
        
    }


    IEnumerator ShowOnceCoroutine()
    {
        StartInfo.gameObject.SetActive(true);
        TitleObject.gameObject.SetActive(true);

        // �ƹ� Ű �Է� �Ǵ� �ƹ� ���̳� Ŭ�� && �Է��� ���� UI��ҿ� �ش����� ���� �� ����
        yield return new WaitUntil(() => Input.anyKeyDown && !EventSystem.current.IsPointerOverGameObject());

        // �� ������� �ʴ� ������Ʈ�� ��Ȱ��ȭ
        StartInfo.gameObject.SetActive(false);
        TitleObject.gameObject.SetActive(false);

        StartCoroutine(ShowMainScreenCoroutine());
    }

    IEnumerator ShowMainScreenCoroutine()
    {
        yield return null;
        StartCoroutine(CamTransitionCoroutine());
    }


    /// <summary>
    /// duration ���� ī�޶� ��ġ�� ���� ��ȯ <br/>
    /// ������ �������� ī�޶� �ڽ����� ������ �ξ ���Ѵٸ� �ٸ� ���¿����� ���� ��ġ�� ������ ��ȯ ����.
    /// </summary>
    IEnumerator CamTransitionCoroutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = Time.deltaTime / duration;
            
            // todo: (����) duration�� �� ���缭 ���������� �̸��� �ϱ�

            cam.transform.position = Vector3.Lerp(cam.transform.position, endPosition, t);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, endRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //cam.transform.position = endPosition;
        //cam.transform.rotation = endRotation;
    }

    /// <summary>
    /// ī�޶� ������ ���� ��ġ�� �ǵ����� �޼���
    /// </summary>
    void InitCamTransform()
    {
        cam.transform.position = startPosition;
        cam.transform.rotation = startRotation;
    }

}
