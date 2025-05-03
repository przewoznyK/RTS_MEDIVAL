using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Unit unit;
    [SerializeField] private FloatingHealthBar floatingHealthBsr;


    private void Start()
    {
        floatingHealthBsr.UpdateHealthBar(unit.GetUnitStats().currentHealth, unit.GetUnitStats().maxHealth);
    }
    public bool TakeDamage(int damage)
    {
        unit.GetUnitStats().SubstractHealth(damage);
        floatingHealthBsr.UpdateHealthBar(unit.GetUnitStats().currentHealth, unit.GetUnitStats().maxHealth);
        if (unit.GetUnitStats().currentHealth <= 0)
        {
            animator.SetTrigger("Death");
            unit.Death();
            return true;
        }
        return false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(10);

        }
    }
}
