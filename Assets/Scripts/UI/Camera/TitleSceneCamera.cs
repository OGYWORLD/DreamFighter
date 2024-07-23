using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

#region 우인혜
#endregion

public class TitleSceneCamera : MonoBehaviour
{
    /// <summary>
    /// 'Press Any Key'를 깜빡거리게 하기 위한 변수
    /// </summary>
    public Graphic StartInfo;

    /// <summary>
    /// 월드 스페이스에 배치된 타이틀 오브젝트
    /// </summary>
    public GameObject TitleObject;

    /// <summary>
    /// 씬 전환 시 사용
    /// </summary>
    PostProcessVolume postProcessVolume;
    ColorGrading colorGradingLayer;

    float startExposure = 0.28f;
    float targetExposure = 7f;

    TitleToMain titleToMain;

    /// <summary>
    /// 보간이 이루어질 시간
    /// </summary>
    public float duration = 2.5f;

    #region 카메라 보간 정보

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
        titleToMain = FindObjectOfType<TitleToMain>();
        postProcessVolume = GetComponent<PostProcessVolume>();
        
        if (postProcessVolume.profile.TryGetSettings(out colorGradingLayer))
        {
            // do nothing
        }
    }

    private void Start()
    {
        TitleObject.gameObject.SetActive(true);
        ShowTitleScreen();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //========================================================================================================

    void ShowTitleScreen()
    {
        
        
        InitCamTransform();
        StartCoroutine(ShowOnceCoroutine());
    }

    IEnumerator ShowOnceCoroutine()
    {
        StartInfo.gameObject.SetActive(true);

        // 아무 키 입력 또는 아무 곳이나 클릭 && 입력한 곳이 UI요소에 해당하지 않을 때 실행
        yield return new WaitUntil(() => Input.anyKeyDown && !EventSystem.current.IsPointerOverGameObject());

        // 더 사용하지 않는 오브젝트를 비활성화
        StartInfo.gameObject.SetActive(false);

        TitleObject.SendMessage("FlyOutTitleCoroutine");

        StartCoroutine(ShowMainScreenCoroutine());
    }

    IEnumerator ShowMainScreenCoroutine()
    {
        yield return null;
        StartCoroutine(CamTransitionCoroutine());
    }


    /// <summary>
    /// duration 동안 카메라 위치와 각도 전환
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

        yield return new WaitForSeconds(2f);
        StartCoroutine(LightOnCoroutine());

    }

    IEnumerator LightOnCoroutine()
    {

        if(colorGradingLayer == null)
        {
            yield break;
        }

        float delta = 0.0f;

        // while (!Mathf.Approximately(colorGradingLayer.postExposure.value, targetExposure))

        while (delta <= duration)
        {
            float t = delta / duration;

            colorGradingLayer.postExposure.value = Mathf.Lerp(startExposure, targetExposure, t);
            delta += Time.deltaTime;
            yield return null;
        }

        //MainCanvasDictionary.Instance.isReadyTitleToMainScene = true;
        titleToMain.isReadyTitleToMainScene = true;
    }

    /// <summary>
    /// 작업 중 변경에 대비해 카메라를 지정된 시작 위치로 되돌리는 메서드
    /// </summary>
    void InitCamTransform()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

}
