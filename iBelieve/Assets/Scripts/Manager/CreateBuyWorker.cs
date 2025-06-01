using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuyWorker : MonoBehaviour
{
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private GameObject buyWorkerPrefab;
    [SerializeField] private GameObject workerPrefab;
    private AchivController achivController;
    private int buyWorkerNum = 0;
    private int workerNum = 0;

    private void Start()
    {
        achivController = FindObjectOfType<AchivController>();
        CreateNewBuyWorker();
    }

    public void CreateNewBuyWorker()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            if (i == buyWorkerNum)
            {
                buyWorkerPrefab.GetComponent<BuyWorker>().Num = i;
                Instantiate(buyWorkerPrefab, spawns[i].gameObject.transform);
            }
        }
        buyWorkerNum++;
    }
    public void CreateNewWorker(WorkerData workerData)
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            if (i == workerNum)
            {
                workerPrefab.GetComponent<Worker>().workerData = workerData;
                workerPrefab.GetComponent<Worker>().Num = workerNum +1;
                Instantiate(workerPrefab, spawns[i].gameObject.transform);
            }
        }
        workerNum++;
    }
}
