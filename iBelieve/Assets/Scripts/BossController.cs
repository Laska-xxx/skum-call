using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bossInPrisonPrefab;
    private Animator animator;
    void Start()
    {
        if (PlayerPrefs.GetInt("GameLevel") == 1)
        {
            Instantiate(bossInPrisonPrefab, gameObject.transform);

        }
        else
        {
            Instantiate(bossPrefab, gameObject.transform);
        }
        animator = GetComponentInChildren<Animator>();
    }
        public void ClickAnim()
    {
        animator.SetTrigger("Click");
    }
}
