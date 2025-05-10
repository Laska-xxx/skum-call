using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNonStop : MonoBehaviour
{
    [SerializeField] private string ctratedTag;
    private void Awake()
    {
        GameObject obj = GameObject.FindWithTag(this.ctratedTag);
        if (obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = this.ctratedTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
