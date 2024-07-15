using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region ������
#endregion

/// <summary>
/// ��Ʈ�� ����� �� Ȱ��ȭ�Ǵ� ��ƼŬ, ��� �̹���(Perfect, good, x)�� �����ϴ� ��ũ��Ʈ �Դϴ�.
/// ��ƼŬ�� �̹����� ������Ʈ Ǯ������ �����Ǹ� ��Ʈ�� �Է¹޴� CLazerSetActive ��ũ��Ʈ���� ȣ��˴ϴ�.
/// </summary>

public class CDisAprNote : MonoBehaviour
{
    public class ResultImage // �̹����� �ʵ�� ������ �ִ� Ŭ����
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

    public Transform resultParents; // ĵ������ ��� �̹��� �θ�

    // ���� ī�޶�
    public Camera mainCamera;

    // Ŭ�� ȿ����
    public AudioSource ef;
    public AudioClip scEF;
    public AudioClip wrEF;

    // ��ƼŬ
    public GameObject scParticle;
    public GameObject wrParticle;

    // Perfect! / Good! / X �̹���
    public GameObject[] resultImage = new GameObject[3];

    // Ǯ ������
    private int poolSize = 5;

    private List<GameObject> scPool = new List<GameObject>(); // ��Ȯ�� �Է� ��ƼŬ
    private List<GameObject> wrPool = new List<GameObject>(); // �߸��� �Է� ��ƼŬ
    private List<ResultImage> resultImg = new List<ResultImage>(); // ��� �̹���

    private int scIdx = 0; // ��Ȯ�� �Է� Ǯ �ε���
    private int wrIdx = 0; // �߸��� �Է� Ǯ �ε���
    private int imgIdx = 0; // �̹��� Ǯ �ε���

    private void Start()
    {
        MakePool();
    }

    void MakePool()
    {
        // scPool
        for(int i = 0; i < poolSize; i++)
        {
            // scPool
            GameObject obj = Instantiate(scParticle, Vector3.zero, Quaternion.Euler(0f, -90f, 0f)); // ��ƼŬ
            obj.SetActive(false);
            scPool.Add(obj);

            // wrPool
            obj = Instantiate(wrParticle, Vector3.zero, Quaternion.Euler(0f, 0f, 90f));
            obj.SetActive(false);
            wrPool.Add(obj);

            // imagePool
            GameObject obj01 = Instantiate(resultImage[0], resultParents);
            obj01.SetActive(false);

            GameObject obj02 = Instantiate(resultImage[1], resultParents);
            obj02.SetActive(false);

            GameObject obj03 = Instantiate(resultImage[2], resultParents);
            obj03.SetActive(false);

            resultImg.Add(new ResultImage() { perfectImage = obj01, goodImage = obj02, wrongImage = obj03 });
        }

    }

    public void ShowSCParticle(Vector3 pos, int category)
    {
        // ��� �̹���
        ImgSetPos(pos, category);

        // ȿ����
        ef.clip = scEF;
        ef.Play();

        scPool[scIdx].transform.position = pos;
        scPool[scIdx].SetActive(true);

        scIdx++;

        if (scIdx == poolSize)
        {
            scIdx = 0;
        }
    }

    public void ShowWRParticle(Vector3 pos)
    {
        // ��� �̹���
        ImgSetPos(pos, 2); // 2: wrong Image

        // ȿ����
        ef.clip = wrEF;
        ef.Play();

        wrPool[wrIdx].transform.position = pos;
        wrPool[wrIdx].SetActive(true);

        wrIdx++;

        if (wrIdx == poolSize)
        {
            wrIdx = 0;
        }
    }

    void ImgSetPos(Vector3 pos, int category)
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
