using UnityEngine;

public enum TeamColorEnum
{
    blue,
    red
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TeamColorEnum playerTeamColor;

    public string playerUnitColor { get; private set; }
    public string playerBuildingColor { get; private set; }
    private string unitBlue = "UnitBlue";
    private string buildingBlue = "BuildingBlue";

    private string unitRed = "UnitRed";
    private string buildingRed = "BuildingRed";


    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (playerTeamColor)
        {
            case TeamColorEnum.blue:
                playerUnitColor = unitBlue;
                playerBuildingColor = buildingBlue;
                break;
            case TeamColorEnum.red:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
