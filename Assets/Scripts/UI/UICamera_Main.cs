using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

#region 우인혜
#endregion

public class UICamera_Main : MonoBehaviour
{
    private Camera cam;

    // UI 요소
    public Graphic StartInfo;

    // 월드 스페이스에 배치된 타이틀 오브젝트
    public GameObject TitleObject;


    #region 카메라 보간 정보

    /// <summary>
    /// 보간이 이루어질 시간
    /// </summary>
    float duration = 3f;

    /// <summary>
    /// 타이틀 씬에서의 카메라 위치 초기값 겸 시작점
    /// </summary>
    readonly Vector3 startPosition = new Vector3(-82.77859f, 15.04829f, 9.848166f);

    /// <summary>
    /// 타이틀 씬에서의 카메라 각도 초기값 겸 시작점
    /// </summary>
    readonly Quaternion startRotation = Quaternion.Euler(new Vector3(354.4679f, 71.50002f, 0f));


    /// <summary>
    /// 타이틀 씬에서 메인 화면으로의 전환을 위한 카메라 위치 끝점
    /// </summary>
    readonly Vector3 endPosition = new Vector3(-73.6115f, 12.48918f, -6.53041f);

    /// <summary>
    /// 타이틀 씬에서 메인 화면으로의 전환을 위한 카메라 각도 끝점
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
        // todo: (인혜) 이 지점에서 기본 BGM이 나오도록 하면 되겠다.

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

        // 아무 키 입력 또는 아무 곳이나 클릭 && 입력한 곳이 UI요소에 해당하지 않을 때 실행
        yield return new WaitUntil(() => Input.anyKeyDown && !EventSystem.current.IsPointerOverGameObject());

        // 더 사용하지 않는 오브젝트를 비활성화
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
    /// duration 동안 카메라 위치와 각도 전환 <br/>
    /// 보간의 시작점을 카메라 자신으로 설정해 두어서 원한다면 다른 상태에서도 지정 위치와 각도로 전환 가능.
    /// </summary>
    IEnumerator CamTransitionCoroutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = Time.deltaTime / duration;
            
            // todo: (인혜) duration에 딱 맞춰서 도착지점에 이르게 하기

            cam.transform.position = Vector3.Lerp(cam.transform.position, endPosition, t);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, endRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //cam.transform.position = endPosition;
        //cam.transform.rotation = endRotation;
    }

    /// <summary>
    /// 카메라를 지정된 시작 위치로 되돌리는 메서드
    /// </summary>
    void InitCamTransform()
    {
        cam.transform.position = startPosition;
        cam.transform.rotation = startRotation;
    }

}
