using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBabls : MonoBehaviour
{
    [SerializeField] private GameObject[] babls;
    private WorkerData workerData;
    private bool isChat = false;
    void Start()
    {
        workerData = gameObject.GetComponentInParent<Worker>().workerData;
        babls[babls.Length - 1].GetComponentInChildren<TextMeshProUGUI>().text = $"{workerData.SpeshalText}";
    }

    public void Chat()
    {
        if (!isChat)
        {
            isChat = true;
            if (Random.Range(1, 20) == 1)
            {
                babls[babls.Length - 1].SetActive(true);
                Invoke("Close", 2.2f);
            }
            else
            {
                babls[Random.Range(0, babls.Length - 2)].SetActive(true);
                Invoke("Close", 1.5f);
            }
        }
        
    }
    private void Close()
    {
        isChat = false;
        foreach (var item in babls)
        {
            item.gameObject.SetActive(false);
        }
    }
}
