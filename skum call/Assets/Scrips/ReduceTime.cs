using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReduceTime : MonoBehaviour
{
    [SerializeField] private Worker[] workers;
    [SerializeField] private Button Button;
    [SerializeField] private Table[] tables;

    private void Start()
    {
        Button.onClick.AddListener(ReduceTimeOnClik);
    }

    public void ReduceTimeOnClik()
    {
        foreach (Worker worker in workers)
        {
            ReduseTime(worker);
        }
    }

    private void ReduseTime(Worker worker)
    {
        if (worker.isBuy)
        {
            worker.curWorkTime += tables[worker.num].timeForClick;
        }
    }
}
