using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Attackable"))
        {
            if (other.gameObject.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(3);
            }
        }
    }

}
