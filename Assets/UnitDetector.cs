using UnityEngine;
using UnityEngine.AI;

public class UnitDetector : MonoBehaviour
{
    [SerializeField] private UnitMovement unitMovement;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private string targetTag;

    private bool hasTarget;

    void Update()
    {
        if(hasTarget == false)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag(targetTag))
                {
                    // PodejdŸ do jednostki
                    unitMovement.enabled = true;
                    unitMovement.GoToTheAttackTarget(collider.transform);
                    Debug.Log("Jednostka wykryta! Idê do: " + collider.name);
                    hasTarget = true;
                    this.enabled = false;
                    break; // Mo¿esz usun¹æ break jeœli chcesz podejœæ do najbli¿szej z wielu
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
