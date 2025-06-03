using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekLvl : MonoBehaviour
{
    private Worker[] workers;
    private Desk[] desks;
    private EndController endController;
    private AchivController achivController;
    private int generalLevel;
    void Start()
    {
        endController = FindObjectOfType<EndController>();
        achivController = FindObjectOfType<AchivController>();
    }

    public void ChekWorkerLvl()
    {
        workers = FindObjectsOfType<Worker>();
        generalLevel = 0;
        int cur = 0;
        foreach (Worker worker in workers)
        {
            generalLevel += worker.Level;
            if (worker.Level >= 20)
            {
                cur++;
            }
        }
        if (cur == 5)
        {
            achivController.GetWorkerLvlAchiv(100);
        }
        if (generalLevel >= 120)
        {
            if (endController != null)
            {
                endController.StartEnd();
            }
        }
    }

    public void ChekDeskLvl()
    {
        desks = FindObjectsOfType<Desk>();
        generalLevel = 0;
        foreach (Desk desk in desks)
        {
            generalLevel += desk.Level;
        }
        if (generalLevel == 100)
        {
            achivController.GetDeskLvlAchiv(generalLevel);
        }
    }
}
