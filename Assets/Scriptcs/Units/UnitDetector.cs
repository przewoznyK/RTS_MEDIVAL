using UnityEngine;
using UnityEngine.AI;

public class UnitDetector : MonoBehaviour
{
    [SerializeField] protected Unit unit;
    [SerializeField] private UnitMovement unitMovement;
    [SerializeField] private float detectionRadius = 10f;

    private bool hasTarget;

    void Update()
    {
        if(hasTarget == false)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag(GameManager.instance.GetUnitEnemyTag(unit.GetTeamColor())))
                {
                    // Podejd� do jednostki
                    unitMovement.enabled = true;
                    unitMovement.GoToTheAttackTarget(collider.transform);
                    Debug.Log("Jednostka wykryta! Id� do: " + collider.name);
                    hasTarget = true;
                    this.enabled = false;
                    break; // Mo�esz usun�� break je�li chcesz podej�� do najbli�szej z wielu
                }
            }
        }

    }

    // Opcjonalnie: wizualizacja w edytorze
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
