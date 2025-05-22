using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphonesOnHead : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject[] headphones;

    public void ChangeHeadphones(int num)
    {
        if (spawnPos.transform.childCount > 0)
        {
            Destroy(spawnPos.transform.GetChild(0).gameObject);
        }
        Instantiate(headphones[num], spawnPos.transform);
    }
}
