using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(GameManager.instance.GetUnitEnemyTag(unit.GetTeamColor())))
        {
            if (other.gameObject.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(3);
            }
        }
    }

}
