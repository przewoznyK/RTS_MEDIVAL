using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public static PlayerResourceManager instance;
    [SerializeField] private int currentAmountWoodResource;
    [SerializeField] private int currentAmountStoneResource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIManager.instance.UpdateUICurrentAmountWoodResource(currentAmountWoodResource);
        UIManager.instance.UpdateUICurrentAmountStoneResource(currentAmountStoneResource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCurrentAmountWoodResource(int value)
    {
        currentAmountWoodResource += value;
        UIManager.instance.UpdateUICurrentAmountWoodResource(currentAmountWoodResource);

    }
    public void UpdateCurrentAmountStoneResource(int value)
    {
        currentAmountStoneResource += value;
        UIManager.instance.UpdateUICurrentAmountStoneResource(currentAmountStoneResource);

    }


}
