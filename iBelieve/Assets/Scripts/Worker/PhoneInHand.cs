using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInHand : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject[] phones;
    void Start()
    {
        Instantiate(phones[0], spawnPos.transform);
    }

    public void ChangePhone()
    {
        Destroy(spawnPos.transform.GetChild(0).gameObject);
        Instantiate(phones[1], spawnPos.transform);
    }
    public void DelPhone()
    {
        Destroy(spawnPos.transform.GetChild(0).gameObject);
    }
}
