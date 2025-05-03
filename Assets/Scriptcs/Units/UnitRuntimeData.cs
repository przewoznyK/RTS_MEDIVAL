using UnityEngine;

public class UnitRuntimeData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public UnitTypeEnum unitType { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public int currentHealth { get; private set; }
    [field: SerializeField] public int maxHealth { get; private set; }

    public UnitRuntimeData(string name, UnitTypeEnum unitType, Sprite sprite, int maxHealth)
    {
        Name = name;
        this.unitType = unitType;
        Sprite = sprite;
        this.currentHealth = maxHealth;
        this.maxHealth = maxHealth;
    }
    public void SubstractHealth(int value)
    {
        currentHealth -= value;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

}
