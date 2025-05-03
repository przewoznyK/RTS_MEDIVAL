using System.Collections;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] private AttackArea attackArea;
    [SerializeField] protected UnitMovement unitMovement;
    internal void StartAttacking()
    {
        StartCoroutine(AttackCycle());
    }

    IEnumerator AttackCycle()
    {
        unitMovement.FaceTarget();
        animator.SetTrigger("Attack");
        //     attackArea.
        attackArea.SetActiveCollider(true);
        yield return new WaitForSeconds(1f);
        attackArea.SetActiveCollider(false);

        //    attackArea.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);

        StartCoroutine(AttackCycle());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        attackArea.SetActiveCollider(false);
    }
}
