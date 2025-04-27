using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Unit unit;
    [SerializeField] private FloatingHealthBar floatingHealthBsr;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        floatingHealthBsr.UpdateHealthBar(currentHealth, maxHealth);
    }
    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;
        floatingHealthBsr.UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            unit.Death();
            return true;
        }
        return false;
    }
}
