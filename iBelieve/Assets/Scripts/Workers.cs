using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "workerData", menuName = "Worker")]
public class Workers : ScriptableObject
{
    [SerializeField] public string PersName; 
    [SerializeField] public Sprite Sprite;
    [SerializeField] public Sprite Icon;
    [SerializeField] public int Level;
    [SerializeField] public int Tilent;
    [SerializeField] public bool IsBuy;
}
