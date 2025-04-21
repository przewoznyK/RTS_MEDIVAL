using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] private AttackArea attackArea;

    internal void StartAttacking()
    {
        StartCoroutine(AttackCycle());
    }

    IEnumerator AttackCycle()
    {
        animator.SetTrigger("Attack");
        attackArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        attackArea.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);

        StartCoroutine(AttackCycle());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
