using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "workerData", menuName = "Worker")]
public class Workers : ScriptableObject
{
    [SerializeField] public string PersName; 
    [SerializeField] public GameObject Sprite;
    [SerializeField] public Sprite Icon;
    [SerializeField] public int Level;
    [SerializeField] public float Tilent = 0.4f;
    [SerializeField] public bool IsBuy;
    [SerializeField] public string SpeshalText;
}
