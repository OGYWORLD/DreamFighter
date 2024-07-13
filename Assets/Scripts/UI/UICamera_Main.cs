using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region ������
#endregion

public class UICamera_Main : MonoBehaviour
{
    //todo: (����) �ν����Ϳ����� �� ������ ��� �Ϸ��ϸ� ��ũ��Ʈ�� �ݿ��ϰ� SerializeField ����.

    private Camera cam;

    float movePosSpeed = 3f;
    float moveRotationSpeed = 3f;

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ��ġ �ʱⰪ �� ������
    /// </summary>
    [SerializeField] Vector3 startPosition = new Vector3(-82.77859f, 15.04829f, 9.848166f);

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ���� �ʱⰪ �� ������
    /// </summary>
    [SerializeField] Quaternion startRotation = Quaternion.Euler(new Vector3(354.4679f, 71.50002f, 0f));


    /// <summary>
    /// Ÿ��Ʋ ������ ���� ȭ�������� ��ȯ�� ���� ī�޶� ��ġ ����
    /// </summary>
    [SerializeField] Vector3 endPosition = new Vector3(-73.6115f, 12.48918f, -6.53041f);

    /// <summary>
    /// Ÿ��Ʋ ������ ���� ȭ�������� ��ȯ�� ���� ī�޶� ���� ����
    /// </summary>
    [SerializeField] Quaternion endRotation = Quaternion.Euler(new Vector3(1.582f, 83.333f, 0.003f));


    //========================================================================================================


    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void OnEnable()
    {
        ShowTitleScreen();
        StartCoroutine(ShowMainScreenCoroutine());
    }


    //========================================================================================================
    
    void ShowTitleScreen()
    {
        // ��Ȯ�� ��ġ �ݿ��� ���� �׽�Ʈ
        //startPosition = cam.transform.position;
        //startRotation = cam.transform.rotation;

        InitTransform();

        //UIManager.Instance.SetActiveUI(UIManager.Instance.titleUI, true);

        // todo: (����) ������� �÷��� ���� ��

        StartCoroutine(ShowMainScreenCoroutine());
    }


    //todo: (����) �ε��Ǹ� ���� ȭ�� �����ֵ��� �ڷ�ƾ ¥��
    IEnumerator ShowMainScreenCoroutine()
    {
        yield return new WaitUntil(() => Input.anyKey);

        CamTransition();

        //UIManager.Instance

    }

    

    void InitTransform()
    {
        cam.transform.position = startPosition;
        cam.transform.rotation = startRotation;
    }

    void CamTransition()
    {
        // todo: (����) ī�޶� ������ ����

    }
}
