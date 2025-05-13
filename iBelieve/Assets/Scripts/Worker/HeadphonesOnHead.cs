using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphonesOnHead : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject[] headphones;

    public void ChangeHeadphonesOne()
    {
        Instantiate(headphones[0], spawnPos.transform);
    }
    public void ChangeHeadphonesTwo()
    {
        Destroy(spawnPos.transform.GetChild(0).gameObject);

        Instantiate(headphones[1], spawnPos.transform);
    }
}
