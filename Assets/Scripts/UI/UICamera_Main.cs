using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region ������
#endregion

public class UICamera_Main : MonoBehaviour
{
    //todo: (����) �ν����Ϳ����� �� ������ ��� �Ϸ��ϸ� ��ũ��Ʈ�� �ݿ��ϰ� SerializeField ����.

    [SerializeField]private Camera cam;

    float movePosSpeed = 3f;
    float moveRotationSpeed = 3f;

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ��ġ �ʱⰪ �� ������
    /// </summary>
    [SerializeField] Vector3 startPosition = new Vector3(-90.1f, 21.75f, 13.1f);

    /// <summary>
    /// Ÿ��Ʋ �������� ī�޶� ���� �ʱⰪ �� ������
    /// </summary>
    [SerializeField] Quaternion startRotation = Quaternion.Euler(new Vector3(3.27f, 71.5f, 0f));


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

    void Start()
    {
        ShowTitleScreen();
        StartCoroutine(ShowMainScreenCoroutine());
    }


    //========================================================================================================
    
    void ShowTitleScreen()
    {
        InitTransform();

        //UIManager.Instance.SetActiveUI(UIManager.Instance.titleUI, true);

        // todo: (����) ������� �÷��� ���� ��
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
