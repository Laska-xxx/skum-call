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
        babls[5].GetComponentInChildren<TextMeshProUGUI>().text = $"{workerData.SpeshalText}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
