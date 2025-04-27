using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform targetPosition;
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = targetPosition.position;
    }
    public void UpdateHealthBar(int currentHealth,  int maxHealth)
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
