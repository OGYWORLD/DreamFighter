using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 오가을
#endregion

/// <summary>
/// 노트가 사라질 때 활성화되는 파티클을 관리하는 스크립트 입니다.
/// 파티클은 오브젝트 풀링으로 관리되며 노트를 입력받는 CLazerSetActive 스크립트에서 호출됩니다.
/// </summary>

public class CDisAprNote : MonoBehaviour
{
    public GameObject scParticle;
    public GameObject wrParticle;

    private int poolSize = 5;

    private List<GameObject> scPool = new List<GameObject>();
    private List<GameObject> wrPool = new List<GameObject>();

    private int scIdx = 0;
    private int wrIdx = 0;

    private void Start()
    {
        MakePool();
    }

    void MakePool()
    {
        // scPool
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(scParticle, Vector3.zero, Quaternion.Euler(0f, -90f, 0f));
            obj.SetActive(false);
            scPool.Add(obj);
        }

        // wrPool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(wrParticle, Vector3.zero, Quaternion.Euler(0f, 0f, 90f));
            obj.SetActive(false);
            wrPool.Add(obj);
        }
    }

    public void ShowSCParticle(Vector3 pos)
    {
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
        wrPool[wrIdx].transform.position = pos;
        wrPool[wrIdx].SetActive(true);

        wrIdx++;

        if (wrIdx == poolSize)
        {
            wrIdx = 0;
        }
    }
}
