using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekLvl : MonoBehaviour
{
    private Worker[] workers;
    private Desk[] desks;
    private EndController endController;
    private AchivController achivController;
    private int generalWorkerLevel;

    void Start()
    {
        endController = FindObjectOfType<EndController>();
        achivController = FindObjectOfType<AchivController>();
    }
    public void ChekWorkerLvl()
    {
        workers = FindObjectsOfType<Worker>();
        generalWorkerLevel = 0;
        int cur = 0;
        foreach (Worker worker in workers)
        {
            generalWorkerLevel += worker.Level;
            if (worker.Level >= 20)
            {
                cur++;
            }
        }
        if (cur == 5)
        {
            achivController.GetWorkerLvlAchiv(100);
        }
        if (generalWorkerLevel >= 120)
        {
            print(generalWorkerLevel);
            if (endController != null)
            {
                endController.StartEnd();
            }
        }
    }
    public void ChekDeskLvl()
    {
        desks = FindObjectsOfType<Desk>();
        generalWorkerLevel = 0;
        foreach (Desk desk in desks)
        {
            generalWorkerLevel += desk.Level;
        }
        if (generalWorkerLevel == 100)
        {
            achivController.GetDeskLvlAchiv(generalWorkerLevel);
        }
    }
}
