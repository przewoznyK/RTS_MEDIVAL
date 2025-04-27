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

    public string GetUnitEnemyTag(TeamColorEnum myTeamColor)
    {
        string enemyTag = "";
        switch (myTeamColor)
        {
            case TeamColorEnum.blue:
                enemyTag = unitRed;
                break;
            case TeamColorEnum.red:
                enemyTag = unitBlue;
                break;
            default:
                break;
        }

        return enemyTag;
    }
}
