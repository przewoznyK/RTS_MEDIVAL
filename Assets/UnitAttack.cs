using System;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    internal void StartAttacking()
    {
        animator.SetBool("IsAttacking", true);
    }

}
