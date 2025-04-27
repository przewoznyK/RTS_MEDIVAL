using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Unit unit;
    [SerializeField] private UnitAttack unitAttack;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(GameManager.instance.GetUnitEnemyTag(unit.GetTeamColor())))
        {
            if (other.gameObject.TryGetComponent<Health>(out Health health))
            {
             //   bool targetIsDead;
                if(health.TakeDamage(3))
                {
                    unitAttack.enabled = false;
                }
                
            }
        }
    }

    public void SetActiveCollider(bool value)
    {
        boxCollider.enabled = value;
    }
}
