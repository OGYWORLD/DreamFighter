using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region 오가을
#endregion

/// <summary>
/// 노트가 사라질 때 활성화되는 파티클, 결과 이미지(Perfect, good, x)를 관리하는 스크립트 입니다.
/// 파티클과 이미지는 오브젝트 풀링으로 관리되며 노트를 입력받는 CLazerSetActive 스크립트에서 호출됩니다.
/// </summary>

public class CDisAprNote : MonoBehaviour
{
    public enum Result
    {
        Perfect,
        Good,
        Wrong
    }

    public class ResultImage // 이미지를 필드로 가지고 있는 클래스
    {
        public GameObject perfectImage { get; set; } 
        public GameObject goodImage { get; set; }
        public GameObject wrongImage { get; set; }

        public GameObject this [int index]
        {
            get
            {
                if(index == 0)
                {
                    return perfectImage;
                }
                else if(index == 1)
                {
                    return goodImage;
                }
                else if(index == 2)
                {
                    return wrongImage;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public Transform resultParents; // 캔버스의 결과 이미지 부모

    // 메인 카메라
    public Camera mainCamera;

    // 클릭 효과음
    public AudioSource scAS;
    public AudioSource wrAS;

    // 파티클
    public GameObject scParticle;
    public GameObject wrParticle;

    // Perfect! / Good! / X 이미지
    public GameObject[] resultImage = new GameObject[3];

    // 풀 사이즈
    protected int poolSize = 5;

    protected List<GameObject> scPool = new List<GameObject>(); // 정확한 입력 파티클
    protected List<GameObject> wrPool = new List<GameObject>(); // 잘못된 입력 파티클
    protected List<ResultImage> resultImg = new List<ResultImage>(); // 결과 이미지

    protected int scIdx = 0; // 정확한 입력 풀 인덱스
    protected int wrIdx = 0; // 잘못된 입력 풀 인덱스
    protected int imgIdx = 0; // 이미지 풀 인덱스

    private void Start()
    {
        MakePool();
    }

    protected virtual void MakePool()
    {
        // scPool
        for(int i = 0; i < poolSize; i++)
        {
            // scPool
            GameObject obj = Instantiate(scParticle, Vector3.zero, Quaternion.Euler(0f, -90f, 0f)); // 파티클
            obj.SetActive(false);
            scPool.Add(obj);

            // wrPool
            obj = Instantiate(wrParticle, Vector3.zero, Quaternion.Euler(0f, 0f, 90f));
            obj.SetActive(false);
            wrPool.Add(obj);

            // imagePool
            GameObject obj01 = Instantiate(resultImage[(int)Result.Perfect], resultParents);
            obj01.SetActive(false);

            GameObject obj02 = Instantiate(resultImage[(int)Result.Good], resultParents);
            obj02.SetActive(false);

            GameObject obj03 = Instantiate(resultImage[(int)Result.Wrong], resultParents);
            obj03.SetActive(false);

            resultImg.Add(new ResultImage() { perfectImage = obj01, goodImage = obj02, wrongImage = obj03 });
        }

    }

    public virtual void ShowSCParticle(Vector3 pos, int category)
    {
        // 결과 이미지
        ImgSetPos(pos, category);

        // 효과음
        scAS.Play();

        scPool[scIdx].transform.position = pos;
        scPool[scIdx].SetActive(true);

        scIdx++;

        if (scIdx == poolSize)
        {
            scIdx = 0;
        }
    }

    public virtual void ShowWRParticle(Vector3 pos)
    {
        // 결과 이미지
        ImgSetPos(pos, (int)Result.Wrong); // 2: wrong Image

        // 효과음
        wrAS.Play();

        wrPool[wrIdx].transform.position = pos;
        wrPool[wrIdx].SetActive(true);

        wrIdx++;

        if (wrIdx == poolSize)
        {
            wrIdx = 0;
        }
    }

    private void ImgSetPos(Vector3 pos, int category)
    {
        resultImg[imgIdx][category].transform.position = mainCamera.WorldToScreenPoint(pos);
        resultImg[imgIdx][category].SetActive(true);

        imgIdx++;

        if (imgIdx == poolSize)
        {
            imgIdx = 0;
        }
    }
}
