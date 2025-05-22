using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuyWorker : MonoBehaviour
{
    [SerializeField] private GameObject[] spawns;
    [SerializeField] private GameObject buyWorkerPrefab;
    private AchivController achivController;
    private int num = 0;

    private void Start()
    {
        achivController = FindObjectOfType<AchivController>();
        CreateNewBuyWorker();
    }

    public void CreateNewBuyWorker()
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            if (i == num)
            {
                buyWorkerPrefab.GetComponent<BuyWorker>().Num = i;
                Instantiate(buyWorkerPrefab, spawns[i].gameObject.transform);
            }
        }
        num++;
    }
}
