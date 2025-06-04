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
    private WorkerData workerData;
    private ReduceTime reduceTime;
    private BoughtWorkers boughtWorkers;
    private AllWorkersData allWorkers;
    

    /*private void Start()
    {
        achivController = FindObjectOfType<AchivController>();
        reduceTime = FindObjectOfType<ReduceTime>();
    }*/
    public void StartWork(AchivController achivController, ReduceTime reduceTime, BoughtWorkers boughtWorkers, AllWorkersData allWorkersData)
    {
        this.achivController = achivController;
        this.reduceTime = reduceTime;
        this.boughtWorkers = boughtWorkers;
        allWorkers = allWorkersData;
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
                workerData.IsBuy = true;
                workerPrefab.GetComponent<Worker>().workerData = workerData;
                workerPrefab.GetComponent<Worker>().Num = workerNum + 1;
                workerPrefab.GetComponent<Worker>().Level = workerData.Level;
                workerPrefab.GetComponent<Desk>().Level = 1;
                Instantiate(workerPrefab, spawns[i].gameObject.transform);
            }
        }
        reduceTime.FindWorkers();
        workerNum++;
    }
    public void LoadWorkers(int num, int level, int dataID, int deskLevel)
    {
        for (int i = 0; i < allWorkers.listWorkers.Count; i++)
        {
            if (allWorkers.listWorkers[i].ID == dataID)
            {
                workerData = allWorkers.listWorkers[i];
            }
        }
        workerData.IsBuy = true;
        workerPrefab.GetComponent<Worker>().workerData = workerData;
        workerPrefab.GetComponent<Worker>().Num = num;
        workerPrefab.GetComponent<Worker>().Level = level;
        workerPrefab.GetComponent<Desk>().Level = deskLevel;
        Instantiate(workerPrefab, spawns[num-1].gameObject.transform);
        if (reduceTime == null)
        {
            reduceTime = FindObjectOfType<ReduceTime>();
        }
        reduceTime.FindWorkers();
        workerNum ++;
        buyWorkerNum ++;
    }
}
