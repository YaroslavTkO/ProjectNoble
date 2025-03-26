using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTouchPlatform : MonoBehaviour
{
    private Collider2D triggerCollider;
    private Animator animator;

    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    public void RemoveColliderAndPlayAnimation()
    {
        if (triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }


        if (animator != null)
        {
            animator.SetTrigger("PlayOnce");
        }
    }
}
