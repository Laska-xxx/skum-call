using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "workerData", menuName = "Worker")]
public class WorkerData : ScriptableObject
{
    [SerializeField] public string PersName;
    [SerializeField] public int ID = 00;
    [SerializeField] public GameObject Sprite;
    [SerializeField] public Sprite Icon;
    [SerializeField] public int Level;
    [SerializeField] public float Tilent = 0.4f;
    [SerializeField] public int PlusCooldown = 0;
    [SerializeField] public bool IsBuy = false;
    [SerializeField] public string SpeshalText;
}
