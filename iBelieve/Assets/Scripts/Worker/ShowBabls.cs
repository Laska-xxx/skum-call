using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBabls : MonoBehaviour
{
    [SerializeField] private GameObject[] babls;
    private Workers workerData;
    void Start()
    {
        workerData = gameObject.GetComponentInParent<Worker>().workerData;
        babls[6].GetComponentInChildren<TextMeshProUGUI>().text = $"{workerData.SpeshalText}";
    }

    public void Chat()
    {
        if (Random.Range(1,20) == 1)
        {
            babls[5].SetActive(true);
        }
        else
        {
            babls[Random.Range(0, babls.Length-1)].SetActive(true);
        }
        Invoke("Close",1.5f);
        
    }
    private void Close()
    {
        foreach (var item in babls)
        {
            item.gameObject.SetActive(false);
        }
    }
}
