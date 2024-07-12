using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 우인혜
#endregion

public class UICamera_Main : MonoBehaviour
{
    //todo: (인혜) 인스펙터에서의 값 조정을 모두 완료하면 스크립트에 반영하고 SerializeField 떼기.

    [SerializeField]private Camera cam;

    float movePosSpeed = 3f;
    float moveRotationSpeed = 3f;

    /// <summary>
    /// 타이틀 씬에서의 카메라 위치 초기값 겸 시작점
    /// </summary>
    [SerializeField] Vector3 startPosition = new Vector3(-90.1f, 21.75f, 13.1f);

    /// <summary>
    /// 타이틀 씬에서의 카메라 각도 초기값 겸 시작점
    /// </summary>
    [SerializeField] Quaternion startRotation = Quaternion.Euler(new Vector3(3.27f, 71.5f, 0f));


    /// <summary>
    /// 타이틀 씬에서 메인 화면으로의 전환을 위한 카메라 위치 끝점
    /// </summary>
    [SerializeField] Vector3 endPosition = new Vector3(-73.6115f, 12.48918f, -6.53041f);

    /// <summary>
    /// 타이틀 씬에서 메인 화면으로의 전환을 위한 카메라 각도 끝점
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

        // todo: (인혜) 배경음악 플레이 시작 등
    }


    //todo: (인혜) 로딩되면 메인 화면 보여주도록 코루틴 짜기
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
        // todo: (인혜) 카메라 움직임 보간

    }
}
