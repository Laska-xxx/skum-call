using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekWorkersLvl : MonoBehaviour
{
    private Worker[] workers;
    private EndController endController;
    private AchivController achivController;
    private int generalLevel;
    void Start()
    {
        endController = FindObjectOfType<EndController>();
        achivController = FindObjectOfType<AchivController>();
    }

    public void ChekLvl()
    {
        workers = FindObjectsOfType<Worker>();
        generalLevel = 0;
        foreach (Worker worker in workers)
        {
            generalLevel += worker.Level;
        }

        if (generalLevel >= 120)
        {
            endController.StartEnd();
        }
    }
}
