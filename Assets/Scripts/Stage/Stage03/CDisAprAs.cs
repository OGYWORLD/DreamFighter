using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

public class CDisAprAs : CDisAprNote
{
    protected override void MakePool()
    {
        // scPool
        for (int i = 0; i < poolSize; i++)
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

    public override void ShowSCParticle(Vector3 pos, int category)
    {
        // 결과 이미지
        resultImg[imgIdx][category].SetActive(true);

        imgIdx++;

        if (imgIdx == poolSize)
        {
            imgIdx = 0;
        }

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

    public override void ShowWRParticle(Vector3 pos)
    {
        // 결과 이미지
        resultImg[imgIdx][(int)Result.Wrong].SetActive(true);

        imgIdx++;

        if (imgIdx == poolSize)
        {
            imgIdx = 0;
        }

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
}
