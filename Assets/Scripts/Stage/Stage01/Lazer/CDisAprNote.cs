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
    public enum Result
    {
        Perfect,
        Good,
        Wrong
    }

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
    public AudioSource scAS;
    public AudioSource wrAS;

    // ��ƼŬ
    public GameObject scParticle;
    public GameObject wrParticle;

    // Perfect! / Good! / X �̹���
    public GameObject[] resultImage = new GameObject[3];

    // Ǯ ������
    protected int poolSize = 5;

    protected List<GameObject> scPool = new List<GameObject>(); // ��Ȯ�� �Է� ��ƼŬ
    protected List<GameObject> wrPool = new List<GameObject>(); // �߸��� �Է� ��ƼŬ
    protected List<ResultImage> resultImg = new List<ResultImage>(); // ��� �̹���

    protected int scIdx = 0; // ��Ȯ�� �Է� Ǯ �ε���
    protected int wrIdx = 0; // �߸��� �Է� Ǯ �ε���
    protected int imgIdx = 0; // �̹��� Ǯ �ε���

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
            GameObject obj = Instantiate(scParticle, Vector3.zero, Quaternion.Euler(0f, -90f, 0f)); // ��ƼŬ
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
        // ��� �̹���
        ImgSetPos(pos, category);

        // ȿ����
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
        // ��� �̹���
        ImgSetPos(pos, (int)Result.Wrong); // 2: wrong Image

        // ȿ����
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
