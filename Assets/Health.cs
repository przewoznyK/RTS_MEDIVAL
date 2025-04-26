using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Unit unit;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            unit.Death();
            return true;
        }
        return false;
    }
}
