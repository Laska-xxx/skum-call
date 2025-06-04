using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;
    private bool isWhithPhone = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("WhithPhone", isWhithPhone);
    }
    public void ChangeAnim()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        isWhithPhone = false;
        animator.SetBool("WhithPhone", isWhithPhone);
    }
    public void ClickAnim()
    {
        animator.SetTrigger("Click");
    }
}
