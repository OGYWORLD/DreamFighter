using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

#region ������
#endregion

public class UIMainCamera : MonoBehaviour
{
    // UI ���
    public Graphic StartInfo;

    // ���� �����̽��� ��ġ�� Ÿ��Ʋ ������Ʈ
    public GameObject TitleObject;


    /// <summary>
    /// ������ �̷���� �ð�
    /// </summary>
    public float duration = 2.5f;

    #region ī�޶� ���� ����

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

    private void OnEnable()
    {
        ShowTitleScreen();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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

        //TitleObject.gameObject.SetActive(false);
        //Invoke("FlyOutTitleCoroutine", 0.1f);
        TitleObject.SendMessage("FlyOutTitleCoroutine");

        StartCoroutine(ShowMainScreenCoroutine());
    }

    IEnumerator ShowMainScreenCoroutine()
    {
        yield return null;
        StartCoroutine(CamTransitionCoroutine());
    }


    /// <summary>
    /// duration ���� ī�޶� ��ġ�� ���� ��ȯ
    /// </summary>
    IEnumerator CamTransitionCoroutine()
    {
        
        float delta = 0.0f;

        while (delta <= duration)
        {
            float t = delta / duration;

            transform.position = Vector3.Slerp(startPosition, endPosition, t);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            delta += Time.deltaTime;
            yield return null;
        }

        TitleObject.SetActive(false);

    }

    /// <summary>
    /// �۾� �� ���濡 ����� ī�޶� ������ ���� ��ġ�� �ǵ����� �޼���
    /// </summary>
    void InitCamTransform()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

}
