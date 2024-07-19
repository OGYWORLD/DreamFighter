using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������
#endregion

public class CDisAprAs : CDisAprNote
{
    protected override void MakePool()
    {
        // scPool
        for (int i = 0; i < poolSize; i++)
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

    public override void ShowSCParticle(Vector3 pos, int category)
    {
        // ��� �̹���
        resultImg[imgIdx][category].SetActive(true);

        imgIdx++;

        if (imgIdx == poolSize)
        {
            imgIdx = 0;
        }

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

    public override void ShowWRParticle(Vector3 pos)
    {
        // ��� �̹���
        resultImg[imgIdx][(int)Result.Wrong].SetActive(true);

        imgIdx++;

        if (imgIdx == poolSize)
        {
            imgIdx = 0;
        }

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
}
