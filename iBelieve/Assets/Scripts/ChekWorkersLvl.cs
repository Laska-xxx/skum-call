using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekWorkersLvl : MonoBehaviour
{
    private Worker[] workers;
    private EndController endController;
    private int generalLevel = 0;
    void Start()
    {
        endController = FindObjectOfType<EndController>();
    }

    public void ChekLvl()
    {
        workers = FindObjectsOfType<Worker>();
        generalLevel = 0;
        foreach (Worker worker in workers)
        {
            generalLevel += worker.Level;
        }

        if (generalLevel >= 96)
        {
            endController.StartEnd();
        }
    }
}
