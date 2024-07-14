using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDisAprNote : MonoBehaviour
{
    public GameObject disAprParticle;

    private int poolSize = 5;
    private List<GameObject> pool = new List<GameObject>();
    private int idx = 0;

    private void Start()
    {
        MakePool();
    }

    void MakePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(disAprParticle, Vector3.zero, Quaternion.Euler(0f, -90f, 0f));
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public void ShowDisAprParticle(Vector3 pos)
    {
        pool[idx].transform.position = pos;
        pool[idx].SetActive(true);

        idx++;

        if (idx == poolSize)
        {
            idx = 0;
        }
    }
}
