using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateChooseWorkers : MonoBehaviour
{
    private AllWorkersData allWorkers;
    [SerializeField] private GameObject iconWorkerPrefab;
    void Start()
    {
        allWorkers = FindObjectOfType<AllWorkersData>();
        foreach (var worker in allWorkers.listWorkers)
        {
            if (worker.IsBuy == false)
            {
                iconWorkerPrefab.GetComponent<ChooseWorker>().workerData = worker;
                Instantiate(iconWorkerPrefab, gameObject.transform);
            }
        }
    }
}
